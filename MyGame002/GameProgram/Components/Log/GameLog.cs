using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MonoUI.Panel;
using MyGame002.MyData;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assimp.Metadata;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
                    foreach(string text in log)
                    {
                        AddTextComponent(text,Color.White);
                    }
                    break;
                case 1:
                    AddTextComponent("開発中。", Color.White);
                    break;
            }
        }
    }
}
