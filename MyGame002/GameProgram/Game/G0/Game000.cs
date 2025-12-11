using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MonoECS.Components.G0;
using System;
using System.Collections.Generic;
using System.Linq;
using Component = MyGame002.MonoECS.Component;

namespace MyGame002.GameProgram.Game.G0
{
    public class Game000 : GameBase
    {
        private bool initialized = false;
        Entity entity = new Entity();
        public void Dispose()
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            if (!initialized)
            {
                return;
            }
        }

        public List<Component> GetComponents()
        {
            List<Entity> entities = new Entity[] { entity }.ToList();
            return EntityUtil.GetAllComponentsFromEntity(entities.ToArray());
        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
            entity.AddComponent(new TextRender(entity, 1, "Hello World", Color.White));
            entity.AddComponent(new ExampleComponent(entity));

            initialized = true;
        }

        public void Update(GameTime gameTime)
        {
            if(!initialized)
            {
                return;
            }
        }
    }
}
