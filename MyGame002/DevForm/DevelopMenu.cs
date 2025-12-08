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
