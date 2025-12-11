using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.GameProgram.Yukari;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Yukari
{
    public class Yukari : GameBase
    {
        //OSもどき
        Entity entity = new Entity();
        Entity textInput = new Entity();
        Entity gameSelector = new Entity();
        KeyboardSystem keyboardSystem;
        public void Draw(GameTime gameTime)
        {

        }

        public void Initialize()
        {

        }
        private void SetupFile()
        {
            MyDataFile myDataFile = new MyDataFile();
            myDataFile.New();
            foreach (string file in Directory.GetFiles(@"C:\Users\youse\OneDrive\画像\Compress"))
            {
                if (Path.GetExtension(file) == ".png")
                {
                    Trace.Write(file);
                    myDataFile.CreateTextureData(Path.GetFileNameWithoutExtension(file), new FileStream(file, FileMode.Open));
                }
            }
            myDataFile.Save("gamedata.mgf");
        }
        public void Start()
        {
            SetupFile();
            MyDataFile myDataFile = new MyDataFile();
            entity.AddComponent(new TextRender(entity, 1,"圧縮！",Color.White));
            TextRender textRender = textInput.AddComponent(new TextRender(textInput, 1, "s", Color.White)) as TextRender;
            textInput.SetPosition(new Vector2(0, (Game1.GetInstance().GetCenter().Y*2f-16.0f)));
            keyboardSystem = new KeyboardSystem(textRender);
        }
        public void Update(GameTime gameTime)
        {
            keyboardSystem.Update(gameTime);
        }

        List<Component> GameBase.GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new Entity[] { entity,textInput });
        }
        public void Dispose()
        {

        }
    }
}