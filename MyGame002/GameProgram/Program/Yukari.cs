using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.MonoECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Program
{
    public class Yukari : GameBase
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
            return EntityUtil.GetAllComponentsFromEntity(new Entity[] { entity });
        }
        public void Dispose()
        {

        }
    }
}