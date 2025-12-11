using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame002
{
    public class ProgramManager
    {
        //プログラムのリスト
        List<GameProgramInfo> gameProgramList = new List<GameProgramInfo>();
        /// <summary>
		/// プログラムを追加
		/// </summary>
		/// <param name="gameProgramInfo">プログラム情報</param>
        public void AddProgram(GameProgramInfo gameProgramInfo)
        {
            gameProgramList.Add(gameProgramInfo);
        }
        /// <summary>
		/// プログラム一覧を取得
		/// </summary>
        public List<GameProgramInfo> GetProgramList()
        {
            return gameProgramList;
        }
    }
}
