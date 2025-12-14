using MyGame002.MyData;
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

        private void CompressButton_Click(object sender, EventArgs e)
        {
            string path = CompressFileInput.Text;
            string[] paths = path.Split('\\');
            string finalPath = "";
            int i = 0;
            if (!Directory.Exists(path))
            {
                Logger.GetInstance().LogError("圧縮先のディレクトリは存在しませんでした。");
                return;
            }
            foreach(string directory in paths)
            {
                if (i != paths.Length)
                {
                    finalPath += directory + "\\";
                }
                i++;
            }
            MyDataFile dataFile = new MyDataFile();
            dataFile.New();
            foreach (string file in Directory.GetFiles(path))
            {
                if (Path.GetExtension(file) == ".png")
                {
                    Logger.GetInstance().Log(Path.GetFileName(file) + "を圧縮しました。");
                    dataFile.CreateTextureData(Path.GetFileName(file), new FileStream(file, FileMode.Open));
                }
                if(Path.GetExtension(file) == ".mp3")
                {
                    Logger.GetInstance().Log(Path.GetFileName(file) + "を圧縮しました。");
                    dataFile.CreateAudioData(Path.GetFileName(file), new FileStream(file, FileMode.Open));
                }
            }
            dataFile.Save(Path.Combine(path,"archive.mdf"));
        }
    }
}
