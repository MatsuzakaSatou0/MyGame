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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = MyGame002.MonoECS.Components.Button;

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
        private int tabIndex = -1;
        private int beforeTabIndex = 0;

        private List<Component> componets = new List<Component>();
        public UIPanel(Entity entity,bool isWindow)
        {
            this.entity = entity;
            this.isWindow = isWindow;
        }
        public void SetWidth(int size)
        {
            windowWidth = size;
        }
        public int GetTabIndex()
        {
            return tabIndex;
        }
        public void Draw(GameTime time)
        {
            
        }
        public TabButton CreateTab(int index, Mat texture)
        {
            isTab = true;
            TabButton button = new TabButton(entity,texture, new Vector2(20, 20),0);
            button.SetOffset(new Vector2(25 * tabNum, 0));
            tabNum++;
            button.SetIndex(index);
            entity.AddComponent(button);
            return button;
        }

        public void SetNum(int num)
        {
            tabNum = num;
        }

        public void Start()
        {
            
        }
        public virtual void Initialize()
        {
            dataFile.Load("MonoUI.mdf");
            if (isWindow)
            {
                var windowRenderComponent = new UIWindow(entity, dataFile.TryGetTexture("UIWindow.png"), new Vector2(windowWidth, 20),0.9f);
                entity.AddComponent(windowRenderComponent);
                windowRenderComponent.DisableAutoScale();
            }
            windowBG = new TextureRender(entity, dataFile.TryGetTexture("UIWindow.png"), new Vector2(windowWidth, renderOffset.Y),0.9f);
            windowBG.SetOffset(new Vector2(0, 20));
            entity.AddComponent(windowBG);
            initialized = true;
            ResizeBG(300);
            Load();
        }
        public virtual void Clear()
        {
            foreach(Component component in componets)
            {
                if(component.GetType() == typeof(TextRender))
                {
                    TextRender render = component as TextRender;
                    render.Dispose();
                    renderOffset -= new Vector2(0, 19);
                }
                entity.RemoveComponent(component as Component);
            }
            componets.Clear();
        }
        List<TabButton> tabButtons = new List<TabButton>();
        public void AddTabButton(TabButton button)
        {
            tabButtons.Add(button);
        }
        public List<TabButton> GetTabButton()
        {
            return tabButtons;
        }
        public void KillTabButton(TabButton button)
        {
            foreach (TabButton tabButton in tabButtons)
            {
                if(tabButton.GetIndex() == button.GetIndex())
                {
                    tabButton.Kill();
                    entity.RemoveComponent(tabButton);
                }
            }
            int i = 0;
            foreach (TabButton tabButton in tabButtons)
            {
                if (!tabButton.IsDead())
                {
                    tabButton.SetOffset(new Vector2(25 * i, 0));
                    i++;
                }
            }
        }
        public virtual void Load()
        {

        }
        public TextRender AddTextComponent(string text,Color color)
        {
            var t = new TextRender(entity, 1, text, color);
            t.SetOffset(renderOffset + new Vector2(0, 19));
            renderOffset += new Vector2(0, 19);
            entity.AddComponent(t);
            componets.Add(t);
            return t;
        }
        public Button AddButtonComponent(string text, Vector2 size,Mat mat)
        {
            var t = new Button(entity,mat, size, 0.99f);
            t.SetOffset(renderOffset + new Vector2(0, 19));
            renderOffset += size;
            entity.AddComponent(t);
            componets.Add(t);
            return t;
        }
        public void ResetRenderOffset()
        {
            renderOffset = new Vector2(0, 0);
        }
        public TextRender AddTextComponent(Entity entity,string text, Color color)
        {
            var t = new TextRender(entity, 1, text, color);
            t.SetOffset(renderOffset + new Vector2(0, 19));
            renderOffset += new Vector2(0, 19);
            entity.AddComponent(t);
            componets.Add(t);
            return t;
        }
        public void ResizeBG(float height)
        {
            windowBG.MakeTexture(dataFile.TryGetTexture("UIWindowBG.png"), new Vector2(windowWidth, height));
        }
        public virtual void Update(GameTime time)
        {
            if(!initialized)
            {
                Initialize();
            }
            if (isTab)
            {
                if (tabIndex != beforeTabIndex)
                {
                    Clear();
                }
                DoTab();
                beforeTabIndex = tabIndex;
                foreach (TabButton button in tabButtons)
                {
                    if(button.IsDead())
                    {
                        continue;
                    }
                    if (button.IsClick())
                    {
                        tabIndex = button.GetIndex();
                    }
                }
            }
        }
        public virtual void DoTab()
        {

        }
    }
}
