using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using System.Collections.Generic;

namespace MyGame002.GameProgram.System
{
    public class ProgramSelector : GameBase
    {
        KeyboardSystem keyboardSystem;
        TextRender inputTextRender;
        TextRender messageRender;

        Entity message = new Entity();
        Entity input = new Entity();

        public ProgramSelector()
        {

        }

        public void Draw(GameTime gameTime)
        {
            message.SetPosition(new Vector2(0, 0));
            input.SetPosition(new Vector2(0, (Game1.GetInstance().GetCenter().Y * 2) - 15));
        }

        public void Initialize()
        {

        }

        public void Start()
        {
            messageRender = message.AddComponent(new TextRender(message, 1, "プログラムのなまえをにゅうりょくしてください", Color.White)) as TextRender;
            inputTextRender = input.AddComponent(new TextRender(input, 1, "", Color.White)) as TextRender;
            keyboardSystem = new KeyboardSystem(inputTextRender);
        }
        public void Update(GameTime gameTime)
        {
            bool isShift = false;
            keyboardSystem.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                LoadProgram();
            }
        }
        private void LoadProgram()
        {
            string programName = inputTextRender.GetText();
            bool found = false;
            foreach (GameProgramInfo programInfo in Game1.GetInstance().GetProgramManager().GetProgramList())
            {
                if (programName == programInfo.GetName())
                {
                    Game1.GetInstance().RegisterGame(programInfo.GetGame());
                    found = true;
                }
            }
            if(found == false)
            {
                messageRender.SetText("プログラムがみつかりませんでした");
            }
        }

        List<Component> GameBase.GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new Entity[] { message, input });
        }
        public void Dispose()
        {

        }
    }
}
