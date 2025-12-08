using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame002.MonoCV;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS.Components
{
    public class Button:TextureRender
    {
        private Vector2 buttonSize;
        private Texture2D texture;
        Entity entity;

        public Button(Entity entity, Mat texture, Vector2 size) : base(entity, texture, size)
        {
            this.entity = entity;
            buttonSize = size;
        }

        public override void Draw(GameTime time)
        {
            if((Mouse.GetState().X <= entity.GetPosition().X || Mouse.GetState().Y <= entity.GetPosition().Y || Mouse.GetState().X >= entity.GetPosition().X+ buttonSize.X || Mouse.GetState().Y >= entity.GetPosition().Y+buttonSize.Y) == false)
            {
                OverCursor();
            }
            base.Draw(time);
        }
        public virtual void OverCursor()
        {

        }
    }
}