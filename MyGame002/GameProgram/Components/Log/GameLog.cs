using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoUI.Panel;
using MyGame002.MyData;
using System.Collections.Generic;
namespace MyGame002.GameProgram.Log
{
    public class GameLog:UIPanel
    {
        private Entity entity;
        private MyDataFile dataFile = new MyDataFile();
        public List<string> log = new List<string>();

        public GameLog(Entity entity, bool isWindow,MyDataFile dataFile) : base(entity, isWindow)
        {
            this.SetWidth(500);
            this.dataFile = dataFile;
        }
        public void Print(string text)
        {
            log.Add(text);
        }
        public override void Load()
        {
            base.Load();
            AddTabButton(CreateTab(0, dataFile.TryGetTexture("LogIcon.png")));
            AddTabButton(CreateTab(1, dataFile.TryGetTexture("LogIcon.png")));
        }
        public override void Update(GameTime time)
        {
            base.Update(time);
        }
        public override void Clear()
        {
            base.Clear();
        }
        public override void DoTab()
        {
            base.DoTab();
            base.Clear();
            switch (GetTabIndex())
            {
                case 0:
                    for (int i = 1; i < 17; i++)
                    {
                        if (0 <= (log.Count - i) && log.Count != 0)
                        {
                            AddTextComponent(log[(log.Count - i)], Color.White);
                        }
                    }
                    break;
                case 1:
                    AddTextComponent("開発中。", Color.White);
                    break;
            }
        }
    }
}
