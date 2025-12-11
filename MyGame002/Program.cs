using MyGame002;
using MyGame002.GameProgram;
using MyGame002.GameProgram.Developer;
using MyGame002.GameProgram.Game;
using MyGame002.GameProgram.Game.G1;
using MyGame002.GameProgram.GameLauncher;
using MyGame002.GameProgram.Program;
using MyGame002.GameProgram.Yukari;
using System.IO;
var launcher = new GameLauncher();
launcher.SkipLogo();
MyGame002.Game1.GetInstance().RegisterGame(launcher);

//プログラムリスト
MyGame002.Game1.GetInstance().GetProgramManager().AddProgram(new GameProgramInfo("Chaser", "1.0.0", new Game001()));
MyGame002.Game1.GetInstance().GetProgramManager().AddProgram(new GameProgramInfo("Predictor", "1.0.0", new Game002()));

//関係のないプログラムリスト
/*
MyGame002.Game1.GetInstance().GetProgramManager().AddProgram(new GameProgramInfo("DevMenu", "デバッグ用", new DevMenu()));
MyGame002.Game1.GetInstance().GetProgramManager().AddProgram(new GameProgramInfo("3dGame", "開発中", new My3dGame()));
MyGame002.Game1.GetInstance().GetProgramManager().AddProgram(new GameProgramInfo("Yukari", "開発中", new Yukari()));
*/

MyGame002.Game1.GetInstance().Run();