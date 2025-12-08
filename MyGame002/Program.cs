using MyGame002;
using MyGame002.GameProgram;
using MyGame002.GameProgram.Developer;
using MyGame002.GameProgram.GameLauncher;
using MyGame002.GameProgram.Program;
using MyGame002.GameProgram.Yukari;
using System.IO;
var launcher = new GameLauncher();
launcher.SkipLogo();
MyGame002.Game1.GetInstance().RegisterGame(launcher);
//MyGame002.Game1.GetInstance().RegisterGame(new My3dGame());

//プログラムリスト
MyGame002.Game1.GetInstance().GetProgramManager().AddProgram(new GameProgramInfo("DebugSelector", "1.0.0", new DevMenu()));
MyGame002.Game1.GetInstance().GetProgramManager().AddProgram(new GameProgramInfo("3dGame", "1.0.0", new My3dGame()));
MyGame002.Game1.GetInstance().GetProgramManager().AddProgram(new GameProgramInfo("Yukari", "1.0.0", new Yukari()));

MyGame002.Game1.GetInstance().Run();
