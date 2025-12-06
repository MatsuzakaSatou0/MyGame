using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS
{
    public interface Component
    {
        public abstract void Draw(GameTime time);
        public abstract void Update(GameTime time);
        public abstract void Start();
    }
}
