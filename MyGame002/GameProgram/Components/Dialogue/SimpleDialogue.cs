using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame002.MonoECS;
using MyGame002.MonoUI.Panel;
using MyGame002.MyData;
using OpenCvSharp;
using OpenCvSharp.Aruco;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyGame002.GameProgram.Components.Dialogue
{
    public class DialogueMessage
    {
        private Mat texture;
        private UIPanel panel;
        private bool isDead;
        public void Kill()
        {
            isDead = true;
            texture.Dispose();
        }
        public bool IsDead()
        {
            return isDead;
        }

        public DialogueMessage(UIPanel panel,Mat texture)
        {
            this.texture = texture;
            this.panel = panel;
        }

        public Mat GetTexture()
        {
            return texture;
        }

        public virtual void Clear()
        {
            panel.ResetRenderOffset();
        }
        public virtual void Draw()
        {

        }
        public virtual void Do()
        {

        }
    }
    public class SimpleDialogue : UIPanel
    {
        private Entity entity;
        private MyDataFile dataFile = new MyDataFile();
        private List<string> log = new List<string>();
        private Dictionary<int,DialogueMessage> messages = new Dictionary<int, DialogueMessage>();
        private int beforeTabIndex = 0;
        public SimpleDialogue(Entity entity, bool isWindow, MyDataFile dataFile) : base(entity, isWindow)
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
        }
        public void AddTab(DialogueMessage message)
        {
            AddTabButton(CreateTab(messages.Count, message.GetTexture()));
            messages.Add(messages.Count,message);
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
            foreach (var message in messages)
            {
                message.Value.Do();
            }
            if (GetTabIndex() != -1)
            {
                if (messages[GetTabIndex()].IsDead() == true)
                {
                    base.Clear();
                    this.KillTabButton(GetTabButton()[GetTabIndex()]);
                }
            }
            if (beforeTabIndex != GetTabIndex())
            {
                base.Clear();
                foreach (var message in messages)
                {
                    if (GetTabIndex() == message.Key)
                    {
                        if (!message.Value.IsDead())
                        {
                            message.Value.Clear();
                            message.Value.Draw();
                        }
                    }
                }
                beforeTabIndex = GetTabIndex();
            }
        }
    }
}