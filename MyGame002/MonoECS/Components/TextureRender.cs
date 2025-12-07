using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework.Content.Pipeline.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS.Components
{
    public class TextureRender : Component
    {
        private Texture2D texture;
        Entity entity;
        public TextureRender(Entity entity)
        {

        }
        public void Draw(GameTime time)
        {
            
        }

        public void Start()
        {
            
        }

        public void Update(GameTime time)
        {
            //Game1.GetInstance()._spriteBatch.Draw();
        }
        public void Dispose()
        {

        }
    }
}
