using Microsoft.Xna.Framework;
using MyGame002.GameProgram.Components.Dialogue;
using MyGame002.GameProgram.Components.Doll;
using MyGame002.GameProgram.Components.Maps;
using MyGame002.GameProgram.RPG;
using MyGame002.MyData;
using OpenCvSharp;
namespace MyGame002.GameProgram.DemoGame
{
    public class DebugMapTale : Tale
    {
        private RPGGame game;
        private MyDataFile mapFile;

        public bool initialized = false;
        public DebugMapTale(RPGGame game, Map map, MyDataFile mapFile) : base(game, map, mapFile)
        {
            this.mapFile = mapFile;
            this.game = game;
            game.GetPlayerComponent().SetPosition(new Microsoft.Xna.Framework.Vector2(0, 0));
        }
        public override void Progress()
        {
            base.Progress();
            if (!initialized)
            {
                for (int i = 0; i <= 10; i++)
                {
                    OneButtonDialogue message = new OneButtonDialogue(game.GetDialogue(), mapFile.TryGetTexture("Triangle.png"), i.ToString());
                    game.GetDialogue().AddTab(message);
                }
                game.GetGameLog().Print("新しいデバッグを発見した。");
                initialized = true;
            }
        }
    }
}
