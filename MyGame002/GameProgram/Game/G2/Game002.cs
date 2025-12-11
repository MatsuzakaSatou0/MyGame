using Microsoft.Xna.Framework;
using MyGame002.MonoECS;
using MyGame002.MonoECS.Components;
using MyGame002.MonoECS.Components.PlayerController;
using MyGame002.MyData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002.GameProgram.Game.G2
{
    public class Game002 : GameBase
    {
        float energy = 0;
        float temperature = 0;
        float heatLevel = 0;
        float cooling = 10;
        float time = 0;
        bool machineCrashed = false;
        string status = "";
        Entity text = new Entity();
        Entity mouseCursor = new Entity();
        Entity energyLamp = new Entity();
        MyDataFile myDataFile;
        public void Dispose()
        {

        }

        public void Draw(GameTime gameTime)
        {
            if (myDataFile == null)
            {
                return;
            }
            text.AddComponent(new TextRender(text, 1, "温度", Color.White));
            mouseCursor.AddComponent(new TextRender(mouseCursor, 1, "> <", Color.Green));
            mouseCursor.AddComponent(new MousePlayerController(mouseCursor));
            energyLamp.AddComponent(new TextureRender(energyLamp, myDataFile.UnpackTextureData()["EnergyLampOn"],new Vector2(50,50)));
            energyLamp.SetPosition(new Vector2(50, 50));
            //temptureButton.AddComponent(new Button(temptureButton,))
        }

        public List<Component> GetComponents()
        {
            return EntityUtil.GetAllComponentsFromEntity(new Entity[] { text, mouseCursor, energyLamp });
        }

        public void Initialize()
        {

        }

        public void Start()
        {
            myDataFile = new MyDataFile();
            myDataFile.Load("gamedata.mgf");
        }
        private void UpdateStatus()
        {
            Random random = new Random();
            heatLevel += random.Next(0, 100) / 100.0f;
            cooling -= random.Next(0, 100) / 1000.0f;
            heatLevel = heatLevel / cooling;
            temperature += heatLevel;
            energy += temperature / 0.35f;
            time = 0;
        }
        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (machineCrashed == false)
            {
                if (time >= 500)
                {
                    UpdateStatus();
                }
            }
            status = "通常";
            if (heatLevel >= 150f)
            {
                status = "メルトダウン";
                machineCrashed = true;
            }
            text.GetComponentAndConvert<TextRender>().SetText("温度" + temperature.ToString() + "\n" + "冷却" + cooling.ToString() + "\n" + "エネルギー" + energy.ToString() + "\n状態:" + status);
        }
    }
}
