using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework.Content.Pipeline.Builder;
using MyGame002.MonoCV;
using OpenCvSharp;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS.Components
{
    public class TextureRender : Component
    {
        private Texture2D texture;
        Entity entity;
        public TextureRender(Entity entity,Mat texture,Vector2 size)
        {
            this.entity = entity;
            Cv2.Resize(texture, texture, new OpenCvSharp.Size(size.X, size.Y), 1.0, 1.0, InterpolationFlags.Cubic);
            Cv2.Flip(texture, texture, FlipMode.XY);
            this.texture = TextureUtil.MatToTexture2D(texture);
        }
        public virtual void Draw(GameTime time)
        {
            if(texture == null)
            {
                return;
            }
            Game1.GetInstance()._spriteBatch.Draw(texture,
                (entity.GetPosition() * Game1.GetInstance().GetScreenSizeMulti() + new Vector2((int)texture.Width / 2, (int)texture.Height / 2)), //位置
                new Microsoft.Xna.Framework.Rectangle(0, 0, (int)texture.Width, (int)texture.Height), //ソース
                Microsoft.Xna.Framework.Color.White,
                (float)(Math.PI) + 0, //回転(90度回す)
                new Vector2((int)texture.Width / 2, (int)texture.Height / 2) * Game1.GetInstance().GetScreenSizeMulti(), //オフセット
                1 * Game1.GetInstance().GetScreenSizeMulti(), //スケール
                SpriteEffects.None, 0);
        }
        public Texture2D GetTexture()
        {
            return texture;
        }
        public Entity GetEntity()
        {
            return entity;
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
