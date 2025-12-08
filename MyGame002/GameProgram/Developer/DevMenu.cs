using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.DevForm;
using MyGame002.GameProgram.System;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Developer
{
    public class DevMenu : GameBase
    {
        Entity textEntity = new Entity();
        Entity menuEntity = new Entity();
        TextRender title;
        TextRender text;
        public void Draw(GameTime gameTime)
        {

        }

        public void Initialize()
        {

        }

        public void Start()
        {
            /*
            MyDataFile myDataFile = new MyDataFile();
            myDataFile.Load(@"D:\MyGame\MyGame002\bin\Tex\data.mydata");
            myDataFile.CreateTextureData("shio",new System.IO.FileStream(@"D:\MyGame\MyGame002\bin\Tex\ComfyUI_00087_.png", System.IO.FileMode.Open));
            entity.AddComponent(new TextureRender(entity, myDataFile.UnpackTextureData()["shio"]));
            */
            title = textEntity.AddComponent(new TextRender(textEntity, 1,"開発メニュー",Color.Yellow)) as TextRender;

            text = menuEntity.AddComponent(new TextRender(menuEntity, 1, "", Color.White)) as TextRender;

            menuEntity.SetPosition(new Vector2(0, 14));
        }
        public void Update(GameTime gameTime)
        {
            text.SetText("1システムツールを起動\n2.ブートアップ");
            if(Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                GameFileTool gameFileTool = new GameFileTool();
                gameFileTool.Show();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                MyGame002.Game1.GetInstance().RegisterGame(new ProgramSelector());
            }
        }

        List<Component> GameBase.GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new Entity[] {textEntity,menuEntity});
        }
        public void Dispose()
        {

        }
    }
}
