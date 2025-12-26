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

namespace MyGame002.MonoUI.Panel
{
    public class UIWindow : Button
    {
        private static bool moveLock = false;
        private bool moving = false;
        private Vector2 mouseVelocity = new Vector2(0,0);
        public UIWindow(Entity entity, Mat texture, Vector2 size,float layer) : base(entity, texture, size, layer)
        {

        }

        public override void Draw(GameTime time)
        {
            if (moving == true && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                UIWindow.moveLock = false;
                moving = false;
            }
            if (moving)
            {
                mouseVelocity = new Vector2(Mouse.GetState().X, Mouse.GetState().Y) - mouseVelocity;
                this.GetEntity().SetPosition(this.GetEntity().GetPosition() + mouseVelocity);
                mouseVelocity = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            }
            base.Draw(time);
        }

        public void Start()
        {
            
        }

        public new void Update(GameTime time)
        {
        }
        public override void OverCursor()
        {
            base.OverCursor();
            if(moving == false && Mouse.GetState().LeftButton == ButtonState.Pressed && UIWindow.moveLock == false)
            {
                UIWindow.moveLock = true;
                mouseVelocity = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                moving = true;
            }
        }
    }
}
