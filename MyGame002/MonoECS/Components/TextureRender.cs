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
        private Vector2 offset = new Vector2(0, 0);
        private Texture2D texture;
        private bool autoScale = false;
        private float layer = 0;
        Entity entity;
        public TextureRender(Entity entity,Mat texture,Vector2 size,float layer=0)
        {
            this.entity = entity;
            this.layer = layer;
            MakeTexture(texture, size);
        }
        public TextureRender(Entity entity, Texture2D texture, Vector2 size, int layer = 0)
        {
            this.entity = entity;
            this.layer = layer;
            this.texture = texture;
        }
        public void SetLayer(float layer)
        {
            this.layer = layer;
        }
        public Vector2 GetOffset()
        {
            return offset;
        }
        public void SetOffset(Vector2 offset)
        {
            this.offset = offset;
        }
        public void MakeTexture(Mat texture,Vector2 size)
        {
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
            if (autoScale)
            {
                Game1.GetInstance()._spriteBatch.Draw(texture,
                    (entity.GetPosition()+ offset + new Vector2((int)texture.Width / 2, (int)texture.Height / 2)), //位置
                    new Microsoft.Xna.Framework.Rectangle(0, 0, (int)texture.Width, (int)texture.Height), //ソース
                    Microsoft.Xna.Framework.Color.White,
                    (float)(Math.PI) + 0, //回転(90度回す)
                    new Vector2((int)texture.Width / 2, (int)texture.Height / 2) * Game1.GetInstance().GetScreenSizeMulti(), //オフセット
                    1 * Game1.GetInstance().GetScreenSizeMulti(), //スケール
                    SpriteEffects.None, layer);
            }
            else
            {
                Game1.GetInstance()._spriteBatch.Draw(texture,
                    (entity.GetPosition()+ offset + new Vector2((int)texture.Width / 2, (int)texture.Height / 2)), //位置
                    new Microsoft.Xna.Framework.Rectangle(0, 0, (int)texture.Width, (int)texture.Height), //ソース
                    Microsoft.Xna.Framework.Color.White,
                    (float)(Math.PI) + 0, //回転(90度回す)
                    new Vector2((int)texture.Width / 2, (int)texture.Height / 2), //オフセット
                    1, //スケール
                    SpriteEffects.None, layer);
            }
        }
        public void DisableAutoScale()
        {
            autoScale = false;
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
