using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components.Maps
{
    public class Tile
    {
        public string tileTextureName = "";
        public Tile(string tileTextureName)
        {
            this.tileTextureName = tileTextureName;
        }
    }
}
