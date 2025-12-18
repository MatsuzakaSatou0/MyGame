using Microsoft.Xna.Framework;
using NAudio;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MyGame002.MonoECS.Components
{
    public class Audio:Component
    {
        WasapiOut asioOut;
        public List<WasapiOut> waves = new List<WasapiOut>();
        public void Draw(GameTime time)
        {
            
        }

        public void Start()
        {
            
        }

        public void Update(GameTime time)
        {
            
        }
        public void StopAll()
        {
            foreach (WasapiOut wave in waves) {
                wave.Stop();
                wave.Dispose();
            }
        }

        public void Wave(MemoryStream stream)
        {
            //streamは破棄されないためstreamを移動する必要がある。
            //ストリームのバイトの仮を用意
            byte[] streamByte = new byte[stream.Length];
            //streamの読み取り位置を0に設定。
            stream.Position = 0;
            //streamByteにstreamのデータに移動
            stream.ReadAtLeast(streamByte, (int)stream.Length);
            //使い捨てストリームを設定
            MemoryStream disposableStream = new MemoryStream(streamByte);
            asioOut = new WasapiOut();
            var audioFile = new WaveFileReader(disposableStream);
            asioOut.Init(audioFile);
            asioOut.Play();
            waves.Add(asioOut);
        }
    }
}
