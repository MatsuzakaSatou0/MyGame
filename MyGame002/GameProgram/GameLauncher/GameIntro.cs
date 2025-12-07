using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content.Pipeline;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame002.MyData;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame002.GameProgram.GameLauncher
{
    public class GameIntro : GameBase
    {
        Entity entity = new Entity();
        public void Draw(GameTime gameTime)
        {

        }

        public void Initialize()
        {

        }

        public void Start()
        {
            
        }
        public void Update(GameTime gameTime)
        {
            
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
