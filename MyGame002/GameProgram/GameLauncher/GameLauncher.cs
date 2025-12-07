using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.GameLauncher
{
    public class GameLauncher : GameBase
    {
        bool skipTitle = false;
        float t = 0;
        TextRender timeText;
        Entity entity = new Entity();
        Video video;
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
            timeText = entity.AddComponent(new TextRender(entity, 1, "", Color.White)) as TextRender;
            video = entity.AddComponent(new Video()) as Video;
            video.SetVideo("System/Video/Demo.mp4");
            video.SetFPS(30);
        }
        public void SkipLogo()
        {
            skipTitle = true;
        }

        public void Update(GameTime gameTime)
        {
            //9000
            if(t >= 9000 || skipTitle)
            {
                //MyGame002.Game1.GetInstance().RegisterGame(new GameIntro());
                var launcher = new GameLauncher();
                MyGame002.Game1.GetInstance().RegisterGame(launcher);
            }
        }

        List<Component> GameBase.GetComponents()
        {
            return entity.GetComponents();
        }
        public void Dispose()
        {

        }
    }
}
