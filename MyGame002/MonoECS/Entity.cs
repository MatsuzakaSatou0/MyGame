using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS
{
    public class Entity
    {
        private Vector2 position = new Vector2(0,0);
        private List<Component> components = new List<Component>();
        public Entity() { 
        
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
        public Component AddComponent(Component component)
        {
            components.Add(component);
            return component;
        }
        public List<Component> GetComponents()
        {
            return components;
        }
    }
}
