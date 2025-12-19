using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components.Maps
{
    public class Map
    {
        public Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();
        public Map(int width,int height) {
            for (int w = 0; w <= width; w++)
            {
                for (int h = 0; h <= height; h++)
                {
                    tiles.Add(new Vector2(w,h),new Tile("Concrete.png"));
                }
            }
        }
    }
}
