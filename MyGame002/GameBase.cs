using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002
{
    public interface GameBase
    {
        public abstract void Start();
        public abstract void Initialize();
        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
        public abstract List<Component> GetComponents();
    }
}
