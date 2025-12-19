using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.MonoCV;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using OpenCvSharp;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components.RPGRender
{
    public class TileRender:Component
    {
        private Map map;
        private Camera camera;
        private MyDataFile mapFile = new MyDataFile();
        private Entity entity;
        private Vector2 tileSize = new Vector2(15,15);
        Mat noneTile;
        private bool initialized = false;
        public TileRender(Entity entity,Map map, MyDataFile mapFile,Camera camera)
        {
            this.map = map;
            this.mapFile = mapFile;
            this.camera = camera;
            this.entity = entity;
        }

        public void Draw(GameTime time)
        {
            if (!initialized)
            {
                //やること：マップのタイルを事前にアロケートできるようにして
                noneTile = mapFile.TryGetTexture("None.png");
                Cv2.Resize(noneTile, noneTile, new OpenCvSharp.Size(tileSize.X, tileSize.Y), 1.0, 1.0, InterpolationFlags.Cubic);
                Cv2.Flip(noneTile, noneTile, FlipMode.XY);

                Texture2D texture = TextureUtil.MatToTexture2D(noneTile);
                foreach (Vector2 tile in map.tiles.Keys)
                {
                    GameTextureRender gameTextureRender = new GameTextureRender(entity, camera, texture, tileSize);
                    gameTextureRender.SetOffset(tile * tileSize);
                    entity.AddComponent(gameTextureRender);
                }
                initialized = true;
            }
        }

        public void Start()
        {
            
        }

        public void Update(GameTime time)
        {
            
        }
    }
}
