using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002
{
    public class KeyboardSystem
    {
        private float backSpaceNeedTime = 500f;
        private float backSpaceTime = 0.0f;
        private int beforeKey = 0;
        private string inputText = "";
        TextRender inputTextRender;
        public KeyboardSystem(TextRender inputTextRender)
        {
            this.inputTextRender = inputTextRender;
        }
        public void SetBackSpaceNeedTime(float backSpaceNeedTime)
        {
            this.backSpaceNeedTime = backSpaceNeedTime;
        }
        public float GetBackSpaceNeedTime()
        {
            return backSpaceNeedTime;
        }
        public void Update(GameTime time)
        {
            bool isShift = false;
            inputTextRender.SetText(inputText);
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            if (Keyboard.GetState().IsKeyUp((Keys)beforeKey))
            {
                beforeKey = 0;
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                backSpaceTime = 0;
            }
            if (keys.Length > 4)
            {
                if (keys.Contains(Keys.LeftShift))
                {
                    isShift = true;
                }
                else
                {
                    return;
                }
            }
            if (keys.Length != 4 && isShift == false)
            {
                return;
            }
            if ((keys.Length != 5 && isShift == true))
            {
                return;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                if(backSpaceTime == 0 || backSpaceTime > GetBackSpaceNeedTime())
                if (inputText.Length != 0)
                {
                    inputText = inputText.Remove(inputText.Length - 1);
                }
                backSpaceTime += time.ElapsedGameTime.Milliseconds;
            }
            foreach (Keys key in keys)
            {
                //Keys.A = 65
                //Keys.Z = 90
                //32
                int keyNum = (int)key;
                if (keyNum >= 65 && keyNum <= 90 || keyNum == (int)Keys.Space)
                {
                    if (keyNum != beforeKey)
                    {
                        beforeKey = keyNum;
                    }
                    else
                    {
                        return;
                    }
                    if (!isShift && keyNum != (int)Keys.Space)
                    {
                        inputText += (char)(keyNum + 32);
                    }
                    else
                    {
                        inputText += (char)(keyNum);
                    }
                }
            }
        }
    }
}
