using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.My3dEngine.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Program
{
    public class My3dGame : GameBase
    {
        string log = "";
        Entity entity = new Entity();
        Entity entity2 = new Entity();
        TextRender debugText;
        Renderer render;
        public void Draw(GameTime gameTime)
        {

        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
            entity.SetPosition(new Vector2(0, 0));
            debugText = this.entity.AddComponent(new TextRender(entity, 1, "", Color.White)) as TextRender;
            render = entity2.AddComponent(new Renderer()) as Renderer;
            Matrix matrix = new Matrix();
        }
        public void Update(GameTime gameTime)
        {
            Print(render.GetPosition().ToString()+"\n"+ render.GetRotation().ToString());
        }
        public void Print(string message)
        {
            debugText.SetText(message);
        }
        List<Component> GameBase.GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new Entity[] { entity, entity2 });
        }
        public void Dispose()
        {

        }
    }
}
