using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenCvSharp;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoCV
{
    public class TextureUtil
    {

        /// <summary>
        /// OpenCVのデータをTexture2Dに変換
        /// </summary>
        public static Texture2D MatToTexture2D(Mat matframe)
        {
            if(Game1.GetInstance().GraphicsDevice == null)
            {
                return null;
            }
            //BGRをRGBに変換します。
            matframe = matframe.CvtColor(ColorConversionCodes.BGR2RGB);
            int i = 0;
            //データを初期化
            Color[] data = new Color[(int)((int)matframe.Size().Width * (int)matframe.Size().Height)];
            for (int y = 0; y < (int)matframe.Size().Height; y++)
            {
                for (int x = 0; x < (int)matframe.Size().Width; x++)
                {
                    //Cv2側の色を取得
                    var col = matframe.At<Vec3b>((int)y, (int)x);
                    //cv2の色を設定
                    data[i] = new Color((int)col.Item0, (int)col.Item1, (int)col.Item2);
                    i++;
                }
            }
            //テクスチャ2dを作成
            Texture2D gameTexture = new Texture2D(Game1.GetInstance().GraphicsDevice, (int)matframe.Size().Width, (int)matframe.Size().Height);
            //カラーデータを設定
            gameTexture.SetData<Color>(0, new Rectangle(0, 0, (int)matframe.Size().Width, (int)matframe.Size().Height), data, 0, (int)matframe.Size().Width * (int)matframe.Size().Height);
            return gameTexture;
        }
    }
}
