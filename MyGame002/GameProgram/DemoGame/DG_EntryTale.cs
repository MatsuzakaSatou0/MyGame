using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.DemoGame.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.DemoGame
{
    public class DG_EntryTale : Tale
    {
        RPGGame game;
        public DG_EntryTale(RPGGame game, Map map, MyDataFile mapFile) : base(game, map, mapFile)
        {
            this.game = game;
        }
        public override void Progress()
        {
            base.Progress();
            game.SetMap(new DG_Map(game));
        }
    }
}
