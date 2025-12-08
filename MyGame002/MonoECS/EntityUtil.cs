using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS
{
    public class EntityUtil
    {
        public static List<Component> GetAllComponentsFromEntity(Entity[] entities)
        {
            List<Component> components = new List<Component>();
            foreach(Entity entity in entities)
            {
                components.AddRange(entity.GetComponents());
            }
            return components;
        }
    }
}
