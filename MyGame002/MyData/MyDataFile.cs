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
        /// 音声データを新規作成後、名前とストリームを設定
        /// </summary>
        public void CreateTextureData(string name, FileStream stream)
        {
            //テクスチャデータ
            TextureData textureData = new TextureData();
            //データを設定
            textureData.Data = Google.Protobuf.ByteString.FromStream(stream);
            //データの名前を設定
            textureData.Name = name;
            data.Textures.Add(textureData);
            stream.Close();
            stream.Dispose();
        }
        /// <summary>
        /// テクスチャデータを新規作成後、名前とストリームを設定
        /// </summary>
        public void CreateAudioData(string name,FileStream stream)
        {
            //テクスチャデータ
            AudioData audioData = new AudioData();
            //データを設定
            audioData.Data = Google.Protobuf.ByteString.FromStream(stream);
            //データの名前を設定
            audioData.Name = name;
            data.Audio.Add(audioData);
            stream.Close();
            stream.Dispose();
        }
        /// <summary>
        /// テクスチャーのデータをMatに変換
        /// </summary>
        public Dictionary<string, Mat> UnpackTextureData()
        {
            //C#の辞書機能。CPPユーザーには馴染みがないかも　std::mapと似ています。
            Dictionary<string, Mat> texture = new Dictionary<string, Mat>();
            if(data == null)
            {
                Logger.GetInstance().LogError("テクスチャーがありません。");
                return null;
            }
            //全テクスチャを取得
            foreach(TextureData textureData in data.Textures)
            {
                //名前|Matデータ として追加
                texture.Add(textureData.Name,Mat.FromStream(new MemoryStream(textureData.Data.ToByteArray()),ImreadModes.Unchanged));
            }
            //テクスチャを返す。
            return texture;
        }
        public Dictionary<string, MemoryStream> UnpackAudioData()
        {
            //C#の辞書機能。CPPユーザーには馴染みがないかも　std::mapと似ています。
            Dictionary<string, MemoryStream> audio = new Dictionary<string, MemoryStream>();
            if(data == null)
            {
                Logger.GetInstance().LogError("データが含まれていません。");
                return null;
            }
            if (data.Audio.Count == 0)
            {
                Logger.GetInstance().LogError("音声データが含まれていません。");
                return null;
            }
            //全テクスチャを取得
            foreach (AudioData data in data.Audio)
            {
                //名前|Matデータ として追加
                audio.Add(data.Name, new MemoryStream(data.Data.ToByteArray()));
            }
            //テクスチャを返す。
            return audio;
        }
        /// <summary>
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
            if(!File.Exists(path))
            {
                Logger.GetInstance().LogError("読み込もうとしたファイルが存在しませんでした。");
                return;
            }
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
