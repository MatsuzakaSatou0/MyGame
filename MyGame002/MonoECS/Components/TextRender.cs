using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS.Components
{
    public class TextRender:Component
    {
        private float size = 0;
        private string text = "EMPTY";
        private Entity entity;
        private Microsoft.Xna.Framework.Color color;
        public TextRender(Entity entity,float size,string text,Microsoft.Xna.Framework.Color color)
        {
            this.entity = entity;
            this.size = size;
            this.text = text;
            this.color = color;
        }
        public string GetText()
        {
            return text;
        }
        public void SetText(string text)
        {
            this.text = text;
        }
        public void SetColor(Microsoft.Xna.Framework.Color color)
        {
            this.color = color;
        }
        public void SetSize(int size)
        {
            this.size = size;
        }
        private Entity GetEntity()
        {
            return this.entity;
        }
        public void Draw(GameTime time)
        {
            Game1.GetInstance()._spriteBatch.DrawString(Game1.GetInstance().GetFont(), text, GetEntity().GetPosition(),color, 0,new Vector2(0,0),size,Microsoft.Xna.Framework.Graphics.SpriteEffects.None,0);
        }

        public void Update(GameTime time)
        {
            
        }

        public void Start()
        {
            
        }
        public void Dispose()
        {

        }
    }
}
