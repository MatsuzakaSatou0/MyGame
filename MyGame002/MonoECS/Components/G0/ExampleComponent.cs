using Microsoft.Xna.Framework;

namespace MyGame002.MonoECS.Components.G0
{
    public class ExampleComponent : Component
    {
        Entity entity;
        public ExampleComponent(Entity entity)
        {
            this.entity = entity;
        }
        public void Draw(GameTime time)
        {
            
        }

        public void Start()
        {
            
        }

        public void Update(GameTime time)
        {
            entity.SetPosition(new Vector2((float)time.TotalGameTime.TotalSeconds*2, (float)time.TotalGameTime.TotalSeconds * 2));
        }
    }
}
