using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS.Components
{
    public class Button
    {
        private Texture2D texture;
        Entity entity;
        public Button(Entity entity, Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(GameTime time)
        {
            Game1.GetInstance()._spriteBatch.Draw(texture, new Vector2(0, 0), Color.White);
        }

        public void Start()
        {

        }

        public void Update(GameTime time)
        {

        }
        public void Dispose()
        {

        }
    }
}