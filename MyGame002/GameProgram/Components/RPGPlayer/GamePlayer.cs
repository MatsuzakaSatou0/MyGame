using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoCV;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components.RPGPlayer
{
    public class GamePlayer:Component
    {
        private string tileTextureName = "";
        private Entity entity;
        private Camera camera;
        private Map map;
        private MyDataFile mapFile;
        private Dictionary<Keys, bool> released = new Dictionary<Keys, bool>();
        private int x = 0;
        private int y = 0;
        private bool started = false;
        public GamePlayer(Entity entity,Camera camera, MyDataFile mapFile,string tileTextureName,Map map)
        {
            this.entity = entity;
            this.camera = camera;
            this.mapFile = mapFile;
            this.tileTextureName = tileTextureName;
            this.map = map;
        }
        public void SetMap(Map map)
        {
            this.map = map;
        }

        public void Draw(GameTime time)
        {
            
        }

        public void Start()
        {
            Mat mat = mapFile.TryGetTexture(tileTextureName);
            Cv2.Resize(mat, mat, new OpenCvSharp.Size(RPGSingleton.size.X, RPGSingleton.size.Y), 1.0, 1.0, InterpolationFlags.Cubic);
            Cv2.Flip(mat, mat, FlipMode.XY);
            Texture2D texture = TextureUtil.MatToTexture2D(mat);
            entity.AddComponent(new GameTextureRender(entity, camera, texture, new Vector2(0, 0), 0.8f));
        }

        public void Update(GameTime time)
        {
            Vector2 moveDirection = new Vector2(0,0);
            entity.GetComponentAndConvert<GameTextureRender>().SetOffset(new Vector2(x, y) * RPGSingleton.size);
            if (GetKeyDown(Keys.A))
            {
                moveDirection = new Vector2(-1, 0);
            }
            if (GetKeyDown(Keys.D))
            {
                moveDirection = new Vector2(1, 0);
            }
            if (GetKeyDown(Keys.W))
            {
                moveDirection = new Vector2(0, -1);
            }
            if (GetKeyDown(Keys.S))
            {
                moveDirection = new Vector2(0, 1);
            }
            Vector2 movePos = new Vector2(x,y)+moveDirection;
            //壁(無）にぶつかったら
            if (map.tiles.ContainsKey(movePos) == false)
            {
                return;
            }
            //壁にぶつかったら
            if (map.tiles[movePos].GetFlag() == TileFlag.Wall)
            {
                return;
            }
            x = (int)movePos.X;
            y = (int)movePos.Y;
            //時間経過処理
            if (moveDirection != Vector2.Zero)
            {
                map.GetTale().Progress();
            }
        }
        public bool GetKeyDown(Keys key)
        {
            if(!released.ContainsKey(key))
            {
                released.Add(key, false);
            }
            if (Keyboard.GetState().IsKeyDown(key) && released[key] == false)
            {
                released[key] = true;
                return true;
            }
            if (Keyboard.GetState().IsKeyUp(key) && released[key] == true)
            {
                released[key] = false;
            }
            return false;
        }

        public Vector2 GetPosition()
        {
            return new Vector2(x, y);
        }

        public void SetPosition(Vector2 position)
        {
            this.x = (int)position.X;
            this.y = (int)position.Y;
        }
    }
}
