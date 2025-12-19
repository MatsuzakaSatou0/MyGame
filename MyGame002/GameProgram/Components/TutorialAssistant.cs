using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using System.Collections.Generic;
using System.IO;

namespace MyGame002.GameProgram.Components
{
    public class TutorialAssistant : Component
    {
        MyDataFile myDataFile = new MyDataFile();
        private Audio audio;
        private Entity entity;
        private TextRender textRender;
        public TutorialAssistant(Entity entity,TextRender textRender)
        {
            this.entity = entity;
            this.textRender = textRender;

            this.audio = entity.AddComponent(new Audio()) as Audio;

            myDataFile.Load("TutorialVoice.mdf");
        }
        public void Draw(GameTime time)
        {
            
        }
        public void Start()
        {
            
        }
        public void Speak(string id,string text)
        {
            foreach (var key in myDataFile.UnpackAudioData().Keys)
            {
                if (key == id)
                {
                    audio.Wave(myDataFile.UnpackAudioData()[id]);
                    textRender.SetText(text);
                }
            }
        }
        public void IsEnd()
        {

        }

        public void Update(GameTime time)
        {
            this.textRender.SetPosition(new Vector2(0,Game1.GetInstance().GetCenter().Y*2 - (textRender.GetSize().Y*1.4f)));
        }
    }
}
