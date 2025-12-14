using Microsoft.Xna.Framework;
using MyGame002.MonoCV;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using NAudio.Wave;
using SharpDX.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram
{
    public class AudioTest : GameBase
    {
        private bool started = false;
        private Dictionary<string,MemoryStream> unpackedAudioData = new Dictionary<string,MemoryStream>();
        private Audio audioComponent;
        private Entity audioEntity = new Entity();
        public void Dispose()
        {
            
        }

        public void Draw(GameTime gameTime)
        {
        }

        public List<Component> GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new List<Entity>() {audioEntity}.ToArray());
        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
            if (audioComponent == null)
            {
                audioEntity.AddComponent(new Audio());
                audioComponent = audioEntity.GetComponentAndConvert<Audio>();
            }
            if (unpackedAudioData.Count == 0 || unpackedAudioData == null)
            {
                MyDataFile myDataFile = new MyDataFile();
                myDataFile.Load("C:\\Users\\youse\\OneDrive\\画像\\Compress\\archive.mdf");
                unpackedAudioData = myDataFile.UnpackAudioData();
            }
            if (unpackedAudioData != null)
            {
                if (unpackedAudioData.ContainsKey("audio.mp3"))
                {
                    audioComponent.Wave(unpackedAudioData["audio.mp3"]);
                }
            }
            else
            {
                Logger.GetInstance().LogError("音声ファイルの初期化に失敗しました。");
            }
            started = true;
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
