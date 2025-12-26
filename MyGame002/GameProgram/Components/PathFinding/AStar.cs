using Microsoft.Xna.Framework;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components.PathFinding
{
    public class AStar : Component
    {

        private List<Vector2> open = new List<Vector2>();
        private List<Vector2> closed = new List<Vector2>();

        private Entity entity;
        private Camera camera;
        private Map map;
        public AStar(Entity entity, Camera camera,Map map)
        {
            this.entity = entity;
            this.camera = camera;
            this.map = map;
        }
        public void GoTo(Vector2 goal)
        {

        }
        public void Draw(GameTime time)
        {
            
        }

        public void Start()
        {
            
        }

        public void Update(GameTime time)
        {
            
        }
        public float CalculateDistance(Vector2 from, Vector2 to)
        {
            float dx = MathF.Abs(to.X - from.X);
            float dy = MathF.Abs(to.Y - from.Y);
            return dx+dy;
        }
    }
}
