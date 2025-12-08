using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002
{
    public class ProgramManager
    {
        List<GameProgramInfo> gameProgramList = new List<GameProgramInfo>();
        public void AddProgram(GameProgramInfo gameProgramInfo)
        {
            gameProgramList.Add(gameProgramInfo);
        }
        public List<GameProgramInfo> GetProgramList()
        {
            return gameProgramList;
        }
    }
}
