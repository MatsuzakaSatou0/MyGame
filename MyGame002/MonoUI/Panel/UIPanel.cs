using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assimp.Metadata;

namespace MyGame002.MonoUI.Panel
{
    public class Tab
    {
        private Mat textureData;
    }
    public class UIPanel : Component
    {
        GameTextureRender windowRender;

        private MyDataFile dataFile = new MyDataFile();
        private TextureRender windowBG;
        private Entity entity;
        private Vector2 renderOffset = new Vector2(0, 0);
        private float windowWidth = 150;
        private bool isWindow = false;
        private bool isTab = false;
        private bool initialized = false;
        private int tabNum = 0;
        private int beforeTabNum = 0;

        private List<Component> componets = new List<Component>();
        public UIPanel(Entity entity,bool isWindow)
        {
            this.entity = entity;
            this.isWindow = isWindow;
        }
        public void Draw(GameTime time)
        {
            
        }
        public TabButton AddTab(int index)
        {
            isTab = true;
            TabButton button = new TabButton(entity, dataFile.UnpackTextureData()["054.png"], new Vector2(20, 20),0);
            button.SetOffset(new Vector2(25 * tabNum, 0));
            tabNum++;
            button.SetIndex(index);
            entity.AddComponent(button);
            return button;
        }

        public void Start()
        {
            
        }
        public void Initialize()
        {
            dataFile.Load("MonoUI.mdf");
            if (isWindow)
            {
                var windowRenderComponent = new UIWindow(entity, dataFile.UnpackTextureData()["UIWindow.png"], new Vector2(windowWidth, 20));
                entity.AddComponent(windowRenderComponent);
                windowRenderComponent.DisableAutoScale();
            }
            windowBG = new TextureRender(entity, dataFile.UnpackTextureData()["UIWindow.png"], new Vector2(windowWidth, renderOffset.Y));
            windowBG.SetOffset(new Vector2(0, 20));
            entity.AddComponent(windowBG);
            initialized = true;
            Load();
        }
        public void Clear()
        {
            foreach(Component component in componets)
            {
                if(component.GetType() == typeof(TextRender))
                {
                    renderOffset -= new Vector2(0, 19);
                }
                entity.RemoveComponent(component as Component);
            }
            Resize();
        }
        List<TabButton> tabButtons = new List<TabButton>();
        public void Load()
        {
            tabButtons.Add(AddTab(0));
            tabButtons.Add(AddTab(1));
        }
        public TextRender AddTextComponent(string text,Color color)
        {
            var t = new TextRender(entity, 1, text, color);
            t.SetOffset(renderOffset + new Vector2(0, 19));
            renderOffset += new Vector2(0, 19);
            entity.AddComponent(t);
            componets.Add(t);
            Resize();
            return t;
        }
        public void Resize()
        {
            windowBG.MakeTexture(dataFile.UnpackTextureData()["UIWindowBG.png"], new Vector2(windowWidth, renderOffset.Y));
        }
        public void Update(GameTime time)
        {
            if(!initialized)
            {
                Initialize();
            }
            if (isTab)
            {
                if (tabNum != beforeTabNum)
                {
                    Clear();
                    DoTab();
                }
                foreach (TabButton button in tabButtons)
                {
                    if (button.IsClick())
                    {
                        tabNum = button.GetIndex();
                    }
                }
                beforeTabNum = tabNum;
            }
        }
        public virtual void DoTab()
        {
            switch (tabNum)
            {
                case 1:
                    AddTextComponent("交渉力", Color.Red);
                    break;
            }
        }
    }
}
