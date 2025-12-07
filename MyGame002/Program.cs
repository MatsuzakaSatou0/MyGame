using MyGame002.GameProgram;
using MyGame002.GameProgram.GameLauncher;
using System.IO;
var launcher = new GameLauncher();
//launcher.SkipLogo();
MyGame002.Game1.GetInstance().RegisterGame(launcher);
MyGame002.Game1.GetInstance().Run();
