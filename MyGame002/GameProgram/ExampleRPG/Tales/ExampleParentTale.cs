using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;

namespace MyGame002.GameProgram.ExampleRPG.Tales
{
    public class ExampleParentTale : Tale
    {
        public ExampleParentTale(RPGGame game, Map map, MyDataFile mapFile) : base(game,map, mapFile)
        {
            this.AddTale(new ExampleTale(game, map,mapFile));
        }
        public override void Progress()
        {
            base.Progress();
        }
    }
}