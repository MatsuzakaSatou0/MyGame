using Microsoft.Xna.Framework;
using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MyData;
using System.Collections.Generic;
using Tile = MyGame002.GameProgram.Components.Maps.Tile;

namespace MyGame002.GameProgram.DemoGame.Maps
{
    public class DG_DebugMap : Map
    {
        private RPGGame game;
        private MyDataFile mapFile = new MyDataFile();
        private Tile tile;
        private Tale tale;
        private Vector2 size = new Vector2(50, 50);
        public DG_DebugMap(RPGGame game) : base(game)
        {
            this.game = game;
            mapFile.Load("RPG.mdf");
            this.tale = new DebugMapTale(game, this, mapFile);
            tile = new Tile("Triangle.png", mapFile);
            for (int x = 0; x <= 50; x++)
            {
                for (int y = 0; y <= 50; y++)
                {
                    tiles.Add(new Vector2(x, y), tile);
                }
            }
        }
        public override Vector2 GetSize()
        {
            return size;
        }
        public override Tale GetTale()
        {
            return tale;
        }
        public override List<Tale> GetTales()
        {
            return new List<Tale>() { tale };
        }
    }
}
