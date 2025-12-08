using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyGame002.MonoECS.Components
{
    public class Video : Component
    {
        float time = -1.0f;
        private float fps = 1.0f;
        private float rotation = 0.0f;
        private Vector2 size = new Vector2(0,0);
        VideoCapture capture;
        Texture2D gameTexture;
        public void Draw(GameTime gameTime)
        {
            if(gameTexture == null)
            {
                gameTexture = new Texture2D(Game1.GetInstance().GraphicsDevice, (int)size.X, (int)size.Y);
            }
            if (capture == null)
            {
                Logger.GetInstance().LogError("[VIDEO]capture is null");
                return;
            }
            if(gameTexture == null)
            {
                Logger.GetInstance().LogError("[VIDEO]gameTexture is null");
                return;
            }
            time += gameTime.ElapsedGameTime.Milliseconds;
            //描画
            Game1.GetInstance()._spriteBatch.Draw(gameTexture,
                Game1.GetInstance().GetCenter(), //位置
                new Rectangle(0, 0, (int)size.X, (int)size.Y), //ソース
                Color.White,
                (float)(Math.PI / 2) + rotation, //回転(90度回す)
                new Vector2((int)size.X / 2, (int)size.Y / 2), //オフセット
                1*Game1.GetInstance().GetScreenSizeMulti(), //スケール
                SpriteEffects.FlipVertically, 0);
        }

        public void Start()
        {
            
        }
        public void SetVideo(string path)
        {
            capture = new VideoCapture(path);
            if(capture == null)
            {
                return;
            }
            size = new Vector2(capture.FrameHeight, capture.FrameWidth);
        }
        public void SetFPS(float fps)
        {
            this.fps = fps;
        }
        public void Update(GameTime gameTime)
        {
            float timePassed = time - gameTime.ElapsedGameTime.Milliseconds;
            //monogameの色を作成
            Color[] data = new Color[(int)(size.X * size.Y)];
            //Cv2画像を作成
            Mat matframe = new Mat((int)size.X, (int)size.Y, MatType.CV_8UC3);

            if (timePassed > 1000 / fps || timePassed == -1)
            {
                capture.Grab();
                if (capture.Read(matframe))
                {
                    int i = 0;
                    //色をRGBに変換
                    matframe = matframe.CvtColor(ColorConversionCodes.BGR2RGB);
                    for (int y = 0; y < (int)size.Y; y++)
                    {
                        for (int x = 0; x < (int)size.X; x++)
                        {
                            //Cv2側の色を取得
                            var col = matframe.At<Vec3b>((int)x, (int)y);
                            //cv2の色を設定
                            data[i] = new Color((int)col.Item0, (int)col.Item1, (int)col.Item2);
                            i++;
                        }
                    }
                    //テクスチャ2dを作成
                    gameTexture = new Texture2D(Game1.GetInstance().GraphicsDevice, (int)size.X, (int)size.Y);
                    //カラーデータを設定
                    gameTexture.SetData<Color>(0, new Rectangle(0, 0, (int)size.X, (int)size.Y), data, 0, (int)size.X * (int)size.Y);
                }
                time = 0;
            }
            else
            {

            }
        }
        public void Dispose()
        {
            capture.Dispose();
        }
    }
}
