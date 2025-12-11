using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002
{
    public class GameProgramInfo
    {
        private string programName = "";
        private string programVersion = "";
        private GameBase gameBase;
        public GameProgramInfo(string programName,string programVersion,GameBase gameBase) {
            this.programName = programName;
            this.programVersion = programVersion;
            this.gameBase = gameBase;
        }
        public GameBase GetGame()
        {
            return gameBase;
        }
        public string GetName()
        {
            return programName;
        }
        public string GetVersion()
        {
            return programVersion;
        }
    }
}
