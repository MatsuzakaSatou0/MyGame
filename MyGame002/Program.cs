using MyGame002;
using MyGame002.GameProgram.RPG;
using MyGame002.MonoUI.Example;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

bool customBoot = true;

if(customBoot)
{
    goto CustomBoot;
}
else if (!Directory.Exists("Programs"))
{
    //強制終了
    goto End;
}
else
{
    //読み込み
    goto Load;
}
Load:
{
    //DLLのリスト
    List<Assembly> programes = new List<Assembly>();
    //Programsフォルダー内のdll読み込み。
    foreach (string path in Directory.GetFiles("Programs"))
    {
        //dllを読み込み追加
        if (Path.GetExtension(path) == ".dll")
        {
            programes.Add(Assembly.LoadFile(Path.GetFullPath(path)));
        }
    }
    foreach (Assembly program in programes)
    {
        //dllの中からentryのtypeファイルを取得。
        var entry = program.GetTypes();
        foreach (Type t in entry)
        {
            var methods = t.GetMethods();
            foreach (MethodInfo info in methods)
            {
                if (info.Name == "main")
                {
                    var main = info.Invoke(null, null);
                }
            }
        }
    }
    Game1.GetInstance().Run();
    goto End;
}
CustomBoot:
{
    Game1.GetInstance().RegisterGame(new RPGGame());
    Game1.GetInstance().Run();
    goto End;
}
End:
{

}