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
using System.Windows.Forms;

namespace MyGame002.MonoUI.Example
{
    internal class MonoUIExample : GameBase
    {
        private bool initialized = false;
        private MyDataFile dataFile = new MyDataFile();
        Entity entity = new Entity();
        Entity entity2 = new Entity();
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
                entities.Add(entity);
                entities.Add(entity2);
                entities.Add(mouseEntity);
                return EntityUtil.GetAllComponentsFromEntity(entities.ToArray());
            }
            return EntityUtil.GetAllComponentsFromEntity(new List<Entity>() {entity,mouseEntity,entity2}.ToArray());
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
                entity.AddComponent(new UIPanel(entity,true));
                entity2.AddComponent(new UIPanel(entity2, false));
                entity2.SetPosition(new Vector2(50, 50));
                mouseEntity.AddComponent(new MousePlayerController(mouseEntity));
                mouseEntity.AddComponent(new TextureRender(mouseEntity, dataFile.UnpackTextureData()["054.png"], new Vector2(30,30)));
                initialized = true;
            }
        }
    }
}
