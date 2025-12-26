using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assimp.Metadata;

namespace MyGame002.MonoECS.Components
{
    public class GameTextureRender : TextureRender
    {
        private float layer = 0.01f;
        private Camera camera;

        public GameTextureRender(Entity entity, Camera camera, Texture2D texture, Vector2 size, float layer) : base(entity, texture, size)
        {
            this.camera = camera;
            this.layer = layer;
        }
        public override void Draw(GameTime time)
        {
            Vector2 screenPosition = new Vector2();

            if(this.camera.GetPositionFromCamera(GetEntity(),out screenPosition))
            {
                if(GetTexture() == null)
                {
                    return;
                }
                Game1.GetInstance()._spriteBatch.Draw(GetTexture(),
                    this.GetOffset() + screenPosition + new Vector2((int)GetTexture().Width / 2, (int)GetTexture().Height / 2), //位置
                    new Microsoft.Xna.Framework.Rectangle(0, 0, (int)GetTexture().Width, (int)GetTexture().Height), //ソース
                    Microsoft.Xna.Framework.Color.White,
                    (float)(Math.PI) + 0, //回転(90度回す)
                    new Vector2((int)GetTexture().Width / 2, (int)GetTexture().Height / 2), //オフセット
                    1*camera.GetSize(), //スケール
                    SpriteEffects.None, layer);
                Game1.GetInstance().AddRenderedCount();
            }
        }
    }
}
