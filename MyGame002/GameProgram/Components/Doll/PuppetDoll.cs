using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

namespace MyGame002.GameProgram.Components.Doll
{
    public class PuppetDoll:Component
    {
        private bool initialized = false;
        Texture2D texture;
        Camera camera;
        Entity entity;
        Vector2 position;
        public PuppetDoll(Entity entity,Camera camera,string characterTexture, MyDataFile mapFile)
        {
            this.entity = entity;
            this.camera = camera;

            Mat mat = mapFile.TryGetTexture(characterTexture);
            Cv2.Resize(mat, mat, new OpenCvSharp.Size(RPGSingleton.size.X, RPGSingleton.size.Y), 1.0, 1.0, InterpolationFlags.Cubic);
            Cv2.Flip(mat, mat, FlipMode.XY);
            texture = TextureUtil.MatToTexture2D(mat);
        }

        public void Draw(GameTime time)
        {
            if(!initialized)
            {
                entity.AddComponent(new GameTextureRender(entity,camera,texture,RPGSingleton.size,0.02f));
                initialized = true;
                return;
            }
            entity.GetComponentAndConvert<GameTextureRender>().SetOffset(RPGSingleton.size * position);
        }
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public void Start()
        {
            
        }

        public void Update(GameTime time)
        {
            
        }
    }
}
