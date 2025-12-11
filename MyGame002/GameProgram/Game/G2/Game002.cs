using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Game.G2
{
    public class Game002 : GameBase
    {
        float temperature = 0;
        float heatLevel = 0;
        float cooling = 10;
        float time = 0;
        bool machineCrashed = false;
        string status = "";
        Entity entity = new Entity();
        public void Dispose()
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            entity.AddComponent(new TextRender(entity,1,"温度",Color.White));
        }

        public List<Component> GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new Entity[]{ entity });
        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            Random random = new Random();
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (machineCrashed == false)
            {
                if (time >= 500)
                {
                    heatLevel += random.Next(0, 100) / 100.0f;
                    cooling -= random.Next(0, 100) / 1000.0f;
                    heatLevel = heatLevel / cooling;
                    temperature += heatLevel;
                    time = 0;
                }
            }
            status = "通常";
            if (heatLevel >= 150f)
            {
                status = "メルトダウン";
                machineCrashed = true;
            }
            entity.GetComponentAndConvert<TextRender>().SetText("温度"+temperature.ToString() + "\n" + "冷却"+ cooling.ToString() + "状態:"+ status);
        }
    }
}
