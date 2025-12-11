using Google.Protobuf;
using Microsoft.Xna.Framework.Graphics;
using OpenCvSharp;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial;
using static Tutorial.GameResource.Types;

//MyGame用のデータファイル
namespace MyGame002.MyData
{
    public class MyDataFile
    {
        GameResource data;
        /// <summary>
        /// テクスチャデータを新規作成後、名前とストリームを設定
        /// </summary>
        public void CreateTextureData(string name,FileStream stream)
        {
            //テクスチャデータ
            TextureData textureData = new TextureData();
            //データを設定
            textureData.Data = Google.Protobuf.ByteString.FromStream(stream);
            //データの名前を設定
            textureData.Name = name;
            data.Textures.Add(textureData);
        }
        /// <summary>
        /// テクスチャーのデータをMatに変換
        /// </summary>
        public Dictionary<string, Mat> UnpackTextureData()
        {
            //C#の辞書機能。CPPユーザーには馴染みがないかも　std::mapと似ています。
            Dictionary<string, Mat> texture = new Dictionary<string, Mat>();
            //全テクスチャを取得
            foreach(TextureData textureData in data.Textures)
            {
                //名前|Matデータ として追加
                texture.Add(textureData.Name,Mat.FromStream(new MemoryStream(textureData.Data.ToByteArray()),ImreadModes.Color));
            }
            //テクスチャを返す。
            return texture;
        }
        /// <summary>
        /// データを新規作成
        /// </summary>
        public void New()
        {
            data = new GameResource();
        }
        /// <summary>
        /// データを読み込み
        /// </summary>
        /// <param name="path">ファイルのパス</param>
        public void Load(string path)
        {
            data = GameResource.Parser.ParseFrom(File.ReadAllBytes(path));
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="path">ファイルのパス</param>
        public void Save(string path)
        {
            if(data==null)
            {
                return;
            }
            using (var output = File.Create(path))
            {
                data.WriteTo(output);
            }
        }
    }
}
