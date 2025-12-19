using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Components
{
    public class RPGCamera:Camera
    {
        float speed = 3;
        public RPGCamera()
        {
            
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                cameraPosition.X += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                cameraPosition.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                cameraPosition.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                cameraPosition.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                if (size < 1.0f)
                {
                    size += 0.01f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                if (size > 0.15f)
                {
                    size -= 0.01f;
                }
            }
        }
    }
}
