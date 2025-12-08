using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.GameProgram.Yukari;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Program
{
    public class Yukari : GameBase
    {
        //OSもどき
        Entity entity = new Entity();
        public void Draw(GameTime gameTime)
        {

        }

        public void Initialize()
        {

        }

        public void Start()
        {
            MyDataFile myDataFile = new MyDataFile();
            myDataFile.Load(@"D:\MyGame\MyGame002\bin\Tex\data.mydata");
            myDataFile.CreateTextureData("yukari", new FileStream(@"D:\MyGame\MyGame002\bin\Tex\ComfyUI_00153_.png", FileMode.Open));
            entity.AddComponent(new ButtonYukariTest(entity, myDataFile.UnpackTextureData()["yukari"],Game1.GetInstance().GetCenter()));
            entity.SetPosition(new Vector2(50, 50));
        }
        public void Update(GameTime gameTime)
        {
            
        }

        List<Component> GameBase.GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new Entity[] { entity });
        }
        public void Dispose()
        {

        }
    }
}