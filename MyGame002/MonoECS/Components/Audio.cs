using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NAudio;
using NAudio.Wave;
namespace MyGame002.MonoECS.Components
{
    public class Audio:Component
    {
        public void Draw(GameTime time)
        {
            
        }

        public void Start()
        {
            
        }

        public void Update(GameTime time)
        {
            
        }

        public void Wave(MemoryStream stream)
        {
            var audioFile = new Mp3FileReader(stream);
            var waveOut = new WaveOutEvent();
            waveOut.Init(audioFile);
            waveOut.Play();
        }
    }
}
