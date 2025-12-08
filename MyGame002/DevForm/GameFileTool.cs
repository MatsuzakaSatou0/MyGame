using SharpFont;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame002.DevForm
{
    public partial class GameFileTool : Form
    {
        string xml = "";
        List<char> chars = new List<char>();
        public GameFileTool()
        {
            InitializeComponent();
        }

        private void GameFileTool_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] texts = File.ReadAllLines(@"D:\MyGame\Bible\jpn-kougo.osis.xml");
            foreach(string text in texts)
            {
                foreach (char c in text)
                {
                    if (!chars.Contains(c))
                    {
                        xml += "<CharacterRegion><Start>&#"+((int)c).ToString()+ ";</Start><End>&#"+ ((int)c).ToString()+ ";</End></CharacterRegion>";
                        chars.Add(c);
                    }
                }
            }
            File.WriteAllText("bible.txt",xml);
            MessageBox.Show("DONE");
        }
    }
}
