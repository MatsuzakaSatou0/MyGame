using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
using System.Windows.Forms;
using Button = MyGame002.MonoECS.Components.Button;

namespace MyGame002.GameProgram.Components.Dialogue
{
    public class OneButtonDialogue : DialogueMessage
    {
        UIPanel panel;
        string text;
        Mat texture;
        Button button;
        public OneButtonDialogue(UIPanel panel, Mat texture,string text) : base(panel, texture)
        {
            this.panel = panel;
            this.text = text;
            this.texture = texture;
        }

        public override void Draw()
        {
            base.Draw();
            panel.AddTextComponent(text, Color.White);
            button = panel.AddButtonComponent(text,new Vector2(50,50), texture);
        }
        public override void Do()
        {
            base.Do();
            if (button != null)
            {
                if (button.IsOver())
                {
                    if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    {
                        this.Kill();
                    }
                }
            }
        }
    }
}
