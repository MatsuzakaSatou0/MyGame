using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame002
{
    public class Logger
    {
        private static Logger _singleInstance = new Logger();
        public static Logger GetInstance()
        {
            return _singleInstance;
        }
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
        public void LogError(string message)
        {
            message += "\n" + Environment.StackTrace;
            DebugTool.GetInstance().ErrorAction(message);
            ErrorWindow errorWindow = new ErrorWindow();
            errorWindow.SetErrorLog(message);
            errorWindow.Show();
            Debug.WriteLine(message);
        }
    }
}
