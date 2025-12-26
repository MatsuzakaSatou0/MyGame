using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoCV;
using MyGame002.MyData;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components.Maps
{
    public enum TileFlag
    {
        None = 0,
        Wall = 1,
    }
    public class Tile
    {
        private TileFlag flag = 0;
        private Texture2D texture;
        public void SetTile(TileFlag flag)
        {
            this.flag = flag;
        }
        public Tile(string tileTextureName, MyDataFile mapFile)
        {
            //テクスチャー変換処理
            Mat mat = mapFile.TryGetTexture(tileTextureName);
            Cv2.Resize(mat, mat, new OpenCvSharp.Size(RPGSingleton.size.X, RPGSingleton.size.Y), 1.0, 1.0, InterpolationFlags.Cubic);
            Cv2.Flip(mat, mat, FlipMode.XY);
            //テクスチャーを設定
            texture = TextureUtil.MatToTexture2D(mat);
        }
        public TileFlag GetFlag()
        {
            return flag;
        }
        public Texture2D GetTile()
        {
            return texture;
        }
        public void SetFlag(TileFlag flag)
        {
            this.flag = flag;
        }
    }
}
