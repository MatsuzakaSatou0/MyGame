using Google.Protobuf;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial;
using static Tutorial.GameResource.Types;

namespace MyGame002.MyData
{
    public class MyDataFile
    {
        GameResource data;
        public void CreateTextureData(string name,FileStream stream)
        {
            TextureData textureData = new TextureData();
            textureData.Data = Google.Protobuf.ByteString.FromStream(stream);
            textureData.Name = name;
            data.Textures.Add(textureData);
        }
        public Dictionary<string,Texture2D> UnpackTextureData()
        {
            Dictionary<string, Texture2D> texture = new Dictionary<string, Texture2D>();
            foreach(TextureData textureData in data.Textures)
            {
                texture.Add(textureData.Name,Texture2D.FromStream(Game1.GetInstance().GraphicsDevice,new MemoryStream(textureData.Data.ToByteArray())));
            }
            return texture;
        }
        public void New()
        {
            data = new GameResource();
        }
        public void Load(string path)
        {
            data = GameResource.Parser.ParseFrom(File.ReadAllBytes(path));
        }
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
