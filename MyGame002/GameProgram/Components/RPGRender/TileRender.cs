using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.RPG;
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
        protected Map map;
        protected Camera camera;
        protected MyDataFile mapFile = new MyDataFile();
        protected Entity entity;

        public List<TextureRender> renders = new List<TextureRender>();

        Mat noneTile;
        private bool initialized = false;
        public TileRender(Entity entity,Map map, MyDataFile mapFile,Camera camera)
        {
            this.map = map;
            this.mapFile = mapFile;
            this.camera = camera;
            this.entity = entity;
        }
        //この中でアロケートしないでください。
        public void Draw(GameTime time)
        {
            if (!initialized)
            {
                for (int x = 0; x < map.GetSize().X; x++)
                {
                    for (int y = 0; y < map.GetSize().Y; y++) {
                        GameTextureRender gameTextureRender = new GameTextureRender(entity, camera, map.tiles[new Vector2(x,y)].GetTile(), RPGSingleton.size, 0.01f);
                        gameTextureRender.SetOffset(new Vector2(x,y) * RPGSingleton.size);
                        entity.AddComponent(gameTextureRender);
                        renders.Add(gameTextureRender);
                    }
                }
                initialized = true;
            }
        }
        public void ClearMap()
        {
            foreach(TextureRender render in renders)
            {
                entity.RemoveComponent(render);
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
