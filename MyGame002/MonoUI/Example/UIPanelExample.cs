using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MonoUI.Panel;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoUI.Example
{
    public class UIPanelExample : UIPanel
    {
        MyDataFile file = new MyDataFile();
        public UIPanelExample(Entity entity, bool isWindow) : base(entity, isWindow)
        {

        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Load()
        {
            base.Load();
            file.Load("MonoUI.mdf");
            AddTabButton(CreateTab(0, file.TryGetTexture("Tab1.png")));
            AddTabButton(CreateTab(1, file.TryGetTexture("MouseCursor.png")));
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

            switch (GetTabIndex())
            {
                case 0:
                    AddTextComponent("交渉力", Color.Red);
                    break;
                case 1:
                    AddTextComponent("ゲーム力", Color.Red);
                    break;
            }
        }
    }
}
