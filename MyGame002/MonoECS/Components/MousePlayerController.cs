using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS.Components
{
    public class MousePlayerController:Component
    {
        private Entity entity;

        private int mouseX = 0;
        private int mouseY = 0;

        private int beforeMouseX = 0;
        private int beforeMouseY = 0;
        private bool beforeMouseActive = false;
        public MousePlayerController(Entity entity)
        {
            this.entity = entity;
        }

        public void Draw(GameTime time)
        {
            
        }

        public void Start()
        {
            
        }
        
        public void Update(GameTime time)
        {
            //更新処理
            mouseX -= beforeMouseX - Mouse.GetState().X;
            mouseY -= beforeMouseY - Mouse.GetState().Y;
            //ウィンドウに戻った瞬間マウスが瞬間移動するのを防ぐ。
            if (Game1.GetInstance().IsActive == true)
            {
                if(beforeMouseActive == false)
                {
                    beforeMouseX = 0;
                    beforeMouseY = 0;
                }
                beforeMouseActive = true;
            }
            else
            {
                beforeMouseActive = false;
            }
            beforeMouseX = Mouse.GetState().X;
            beforeMouseY =  Mouse.GetState().Y;
            entity.SetPosition(new Vector2(mouseX, mouseY));
        }
        public Vector2 GetMouseVelocity()
        {
            return new Vector2(beforeMouseX, beforeMouseY);
        }

    }
}
