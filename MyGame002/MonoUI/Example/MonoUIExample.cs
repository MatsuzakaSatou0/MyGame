using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MonoUI.Panel;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoUI.Example
{
    internal class MonoUIExample : GameBase
    {
        private bool initialized = false;
        private MyDataFile dataFile = new MyDataFile();
        Entity tab = new Entity();
        Entity taskbar = new Entity();
        Entity mouseEntity = new Entity();
        public void Dispose()
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            
        }

        public List<Component> GetComponents()
        {
            if (initialized)
            {
                List<Entity> entities = new List<Entity>();
                entities.Add(tab);
                entities.Add(mouseEntity);
                entities.Add(taskbar);
                return EntityUtil.GetAllComponentsFromEntity(entities.ToArray());
            }
            return EntityUtil.GetAllComponentsFromEntity(new List<Entity>() {mouseEntity}.ToArray());
        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            if(!initialized)
            {
                dataFile.Load("MonoUI.mdf");
                tab.AddComponent(new UIPanelExample(tab,true));
                mouseEntity.AddComponent(new MousePlayerController(mouseEntity));
                mouseEntity.AddComponent(new TextureRender(mouseEntity, dataFile.TryGetTexture("MouseCursor.png"), new Vector2(30,30),1));

                taskbar.AddComponent(new Button(taskbar, dataFile.TryGetTexture("Tab1.png"),new Vector2(50, 50),0));
                taskbar.SetPosition(new Vector2(0, Game1.GetInstance().GetCenter().Y * 2 - 50));
                initialized = true;
            }
        }
    }
}
