using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame002
{
    //比率設定などの予定していない挙動にはなるが、将来的な実装を考えての開発用メニュー
    public partial class DevelopMenu : Form
    {
        public DevelopMenu()
        {
            InitializeComponent();
        }

        private void windowSizeNum_ValueChanged(object sender, EventArgs e)
        {
            Game1.GetInstance().SetScreenSizeMulti((float)windowSizeNum.Value);
        }
    }
}
