using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = MyGame002.MonoECS.Components.Button;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MyGame002.GameProgram.Yukari
{
    public class ButtonYukariTest : Button
    {
        public ButtonYukariTest(Entity entity, Mat texture, Vector2 size) : base(entity, texture, size)
        {

        }
        public override void OverCursor()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                MessageBox.Show("Wow");
            }
        }
    }
}
