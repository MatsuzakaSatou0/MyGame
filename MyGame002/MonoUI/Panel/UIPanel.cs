using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assimp.Metadata;

namespace MyGame002.MonoUI.Panel
{
    public class UIPanel : Component
    {
        GameTextureRender windowRender;

        private MyDataFile dataFile = new MyDataFile();
        private TextureRender windowBG;
        private Entity entity;
        private Vector2 renderOffset = new Vector2(0, 0);
        private float windowWidth = 150;
        public bool isWindow = false
        public bool isTab = false;
        private bool initialized = false;
        public UIPanel(Entity entity,bool isWindow)
        {
            this.entity = entity;
            this.isWindow = isWindow;
        }
        public void Draw(GameTime time)
        {
            if(isWindow)
            {
                
            }
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
            for (int i = 0; i <= 5; i++)
            {
                AddTextComponent("交渉力" + i.ToString(), Color.Red);
            }
            initialized = true;
        }
        public TextRender AddTextComponent(string text,Color color)
        {
            var t = new TextRender(entity, 1, text, color);
            t.SetOffset(renderOffset + new Vector2(0, 19));
            renderOffset += new Vector2(0, 19);
            entity.AddComponent(t);
            windowBG.MakeTexture(dataFile.UnpackTextureData()["UIWindowBG.png"], new Vector2(windowWidth, renderOffset.Y));
            return t;
        }
        public void Update(GameTime time)
        {
            if(!initialized)
            {
                Initialize();
            }
        }
    }
}
