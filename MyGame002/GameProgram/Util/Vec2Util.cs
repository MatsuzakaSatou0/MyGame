using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Util
{
    public class Vec2Util
    {
        public static float Distance(Vector2 a,Vector2 b)
        {
            float distance = MathF.Abs(a.X - b.X);
            distance += MathF.Abs(a.Y - b.Y);
            return distance;
        }
    }
}
