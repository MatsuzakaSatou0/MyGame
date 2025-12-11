using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.MonoECS.Components.GameAI
{
    public class PlayerChaser : Component
    {
        string debugText = "";
        Entity entity;
        Vector2 chasePos;

        public void Draw(GameTime gameTime)
        {
            //どうやら座標系を平行移動させないと、0,0を中心にするらしい？
            float radian = MathF.Atan2(chasePos.Y - entity.GetPosition().Y,chasePos.X- entity.GetPosition().X);
            //まんま極座標。
            Vector2 newPos = new Vector2(MathF.Cos(radian), MathF.Sin(radian));
            entity.SetPosition(entity.GetPosition() + newPos);
            //デバッグ用表示
            debugText = "R:" + radian.ToString() + "NP:" + newPos.ToString();
        }
        public string GetDebugText()
        {
            return debugText;
        }
        public void SetChasePosition(Vector2 pos)
        {
            chasePos = pos;
        }
        public void Update(GameTime gameTime)
        {

        }

        public PlayerChaser(Entity entity)
        {
            this.entity = entity;
        }

        public void Start()
        {
            
        }
    }
}
