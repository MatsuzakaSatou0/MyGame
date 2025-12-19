using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS.Components
{
    public class TabButton : Button
    {
        private bool isOver = false;
        private int index = 0;
        public TabButton(Entity entity, Mat texture, Vector2 size,int index) : base(entity, texture, size,index)
        {
            this.index = index;
        }
        public override void OverCursor()
        {
            base.OverCursor();
            isOver = true;
        }
        public int GetIndex()
        {
            return index;
        }
        public void SetIndex(int index)
        {
            this.index = index;
        }
        public override void Draw(GameTime time)
        {
            isOver = false;
            base.Draw(time);
        }
        public bool IsClick()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Released)
            {
                return false;
            }
            return isOver;
        }
    }
}
