using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame002.GameProgram
{
    public class SimpleGame : GameBase
    {
        float t = 0;
        TextRender timeText;
        Entity entity = new Entity();
        public void Draw(GameTime gameTime)
        {
            //経過時間
            t += gameTime.ElapsedGameTime.Milliseconds;
            timeText.SetText(t.ToString());
        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
            timeText = entity.AddComponent(new TextRender(entity,1,"Game",Color.White)) as TextRender;
            Video video = entity.AddComponent(new Video()) as Video;
            video.SetFPS(30);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
            {
                Game1.GetInstance().RegisterGame(new GameIntro());
            }
        }

        List<Component> GameBase.GetComponents()
        {
            return entity.GetComponents();
        }
    }
}
