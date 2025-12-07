using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002
{
    public class DebugTool
    {
        private string allLog = "";
        private string lastMessage = "";
        private static DebugTool _singleInstance = new DebugTool();
        public static DebugTool GetInstance()
        {
            return _singleInstance;
        }
        public void StopGame()
        {
            Game1.GetInstance().StopGame();
        }
        public void StartGame()
        {
            Game1.GetInstance().StartGame();
        }
        public void ErrorAction()
        {
            lastMessage = "Unkown Error";
            SystemSounds.Beep.Play();
            Game1.GetInstance().StopGame();
        }
        public string GetLastMessage()
        {
            return lastMessage;
        }

        public void ErrorAction(string message)
        {
            lastMessage = message;
            SystemSounds.Beep.Play();
            Game1.GetInstance().StopGame();
        }
    }
}
