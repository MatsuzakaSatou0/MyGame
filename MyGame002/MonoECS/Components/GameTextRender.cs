using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenCvSharp;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assimp.Metadata;
using static System.Net.Mime.MediaTypeNames;
using Color = Microsoft.Xna.Framework.Color;

namespace MyGame002.MonoECS.Components
{
    public class GameTextRender : TextRender
    {
        private float layer = 0.01f;
        private float size = 1f;
        private string text = "";
        private Color color;
        private Camera camera;
        private Vector2 position;
        private bool isPosition = false;

        public GameTextRender(Entity entity, Camera camera, string text, float size, Color color, float layer) : base(entity, size, text, color)
        {
            this.text = text;
            this.camera = camera;
            this.layer = layer;
            this.color = color;
        }
        public GameTextRender(Entity entity, Vector2 position, Camera camera, string text, float size, Color color, float layer) : base(entity, size, text, color)
        {
            this.size = size;
            this.text = text;
            this.camera = camera;
            this.layer = layer;
            this.color = color;
            this.position = position;
            this.isPosition = true;
        }
        public override void Draw(GameTime time)
        {
            Vector2 screenPosition = new Vector2();
            if(isPosition == false)
            {
                if (this.camera.GetPositionFromCamera(GetEntity(), out screenPosition))
                {
                    Game1.GetInstance()._spriteBatch.DrawString(Game1.GetInstance().GetFont(), text, GetEntity().GetPosition(), color, 0, new Vector2(0, 0), size, SpriteEffects.None, 0.99f);
                    Game1.GetInstance().AddRenderedCount();
                }
            }
            else
            {

                if (this.camera.GetPositionFromCamera(position, out screenPosition))
                {
                    Game1.GetInstance()._spriteBatch.DrawString(Game1.GetInstance().GetFont(), text, screenPosition, color, 0, new Vector2(0, 0), size, SpriteEffects.None, 0.99f);
                    Game1.GetInstance().AddRenderedCount();
                }
            }
        }
    }
}
