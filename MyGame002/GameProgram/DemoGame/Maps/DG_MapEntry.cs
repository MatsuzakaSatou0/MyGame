using Microsoft.Xna.Framework;
using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MyData;
using System.Collections.Generic;
using Tile = MyGame002.GameProgram.Components.Maps.Tile;

namespace MyGame002.GameProgram.DemoGame.Maps
{
    public class DG_MapEntry:Map
    {
        private RPGGame game;
        private MyDataFile mapFile = new MyDataFile();
        private Tile tile;
        private Tale tale;
        private Vector2 size = new Vector2(0, 0);
        public DG_MapEntry(RPGGame game) : base(game)
        {
            this.game = game;
            mapFile.Load("RPG.mdf");
            this.tale = new DG_EntryTale(game, this, mapFile);
            tile = new Tile("Concrete.png", mapFile);
            tiles.Add(new Vector2(0,0), tile);
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
