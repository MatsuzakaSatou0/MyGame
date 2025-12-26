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
        private Vector2 offset = new Vector2();
        private Entity entity;
        private Microsoft.Xna.Framework.Color color;
        public TextRender(Entity entity,float size,string text,Microsoft.Xna.Framework.Color color)
        {
            this.entity = entity;
            this.size = size;
            this.text = text;
            this.color = color;
        }
        public void SetPosition(Vector2 position)
        {
            entity.SetPosition(position);
        }
        public void SetOffset(Vector2 offset)
        {
            this.offset = offset;
        }
        public Vector2 GetSize()
        {
            float x = 0.0f;
            float y = 0.0f;
            x = Game1.GetInstance().GetFont().Glyphs[0].BoundsInTexture.Width;
            y = Game1.GetInstance().GetFont().Glyphs[0].BoundsInTexture.Height;
            return new Vector2(text.Length * x,y);
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
        public Entity GetEntity()
        {
            return this.entity;
        }
        public virtual void Draw(GameTime time)
        {
            foreach(var c in text) {
                if (!Game1.GetInstance().GetFont().Characters.Contains(c))
                {
                    Game1.GetInstance()._spriteBatch.DrawString(Game1.GetInstance().GetFont(), "BAD CHAR", GetEntity().GetPosition() + offset, color, 0, new Vector2(0, 0), size, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0.99f);
                    return;
                }
             }
            Game1.GetInstance()._spriteBatch.DrawString(Game1.GetInstance().GetFont(), text, GetEntity().GetPosition()+offset, color, 0,new Vector2(0,0),size,Microsoft.Xna.Framework.Graphics.SpriteEffects.None,0.99f);
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
