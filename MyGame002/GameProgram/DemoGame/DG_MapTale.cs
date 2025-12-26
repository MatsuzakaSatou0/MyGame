using Microsoft.Xna.Framework;
using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.DemoGame.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoECS;
using MyGame002.MyData;
using System;
using System.Windows.Forms;

namespace MyGame002.GameProgram.DemoGame
{
    public class DG_MapTale : Tale
    {
        private DG_DebugMap dgMap;
        PuppetDoll debugPuppet;
        RPGGame game;
        public DG_MapTale(RPGGame game, Map map, MyDataFile mapFile) : base(game, map, mapFile)
        {
            this.game = game;
            Entity debug = AddPuppet("DebugTile.png");
            debugPuppet = debug.GetComponentAndConvert<PuppetDoll>();
            debugPuppet.SetPosition(new Vector2(2, 0));
        }
        public override void Progress()
        {
            base.Progress();
            Vector2 distanceVec = game.GetPlayerComponent().GetPosition() - debugPuppet.GetPosition();
            float distance = MathF.Abs(distanceVec.X - distanceVec.Y);
            if(distance < 1)
            {
                if (dgMap == null)
                {
                    dgMap = new DG_DebugMap(game);
                }
                game.SetMap(dgMap);
            }
        }
    }
}
