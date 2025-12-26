using Microsoft.Xna.Framework;
using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.Components.PathFinding;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;

namespace MyGame002.GameProgram.ExampleRPG.Tales
{
    public class ExampleTale : Tale
    {
        private Entity entity;
        private Camera camera;
        private Map map;
        AStar aStar;
        public ExampleTale(RPGGame game,Map map, MyDataFile mapFile) : base(game, map, mapFile)
        {
            AddPuppet("None.png");
            entity = AddPuppet("Triangle.png");
            this.camera = game.GetCamera();
            this.map = map;
        }
        public override bool TaleCheck()
        {
            return false;
        }
        public override void Progress()
        {
            base.Progress();
        }
    }
}