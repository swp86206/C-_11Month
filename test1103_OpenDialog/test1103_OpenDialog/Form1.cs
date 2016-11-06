using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1103_OpenDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            //fontDialog1.ShowDialog();
            //colorDialog1.ShowDialog();

            DialogResult result = openFileDialog1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\temp"; //指定前往該路徑
            openFileDialog1.Filter = "文字檔|*.txt|所有檔案|*,*"; //指定過濾條件
            //openFileDialog1.ShowDialog();
            DialogResult result = openFileDialog1.ShowDialog(); //呼叫ShowDialog對話格
            if (result != DialogResult.OK)
                return;
            button1.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:\\temp"; //指定前往該路徑
            saveFileDialog1.Filter = "文字檔|*.txt|所有檔案|*,*"; //指定過濾條件
            saveFileDialog1.DefaultExt = ".txt";  //DefaultExt 預設副檔名
            
            //openFileDialog1.ShowDialog();
            DialogResult result = saveFileDialog1.ShowDialog(); //呼叫ShowDialog對話格
            if (result != DialogResult.OK)
                return;
            button1.Text = saveFileDialog1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 只秀出檔名,而不是路徑(1)
            string sFileName = @"C:\temp\test.txt";
            int iPosition = sFileName.LastIndexOf("\\"); // IndexOf 找最後一個倒斜線 \ , 兩個倒斜線表示一個倒斜線
            sFileName = sFileName.Substring(iPosition + 1); // iPosition + 1(iPosition 以後的部分),用Substring 全部抓出來
            button4.Text = sFileName;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 只秀出檔名,而不是路徑(2)
            string sFileName = @"C:\temp\test.txt";
            string[] temp = sFileName.Split('\\'); //  Split 傳回字串陣列, char 故用單引號
            button5.Text = temp[temp.Length - 1]; // 長度-1 是最後一項
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 只秀出檔名,而不是路徑(3)
            string sFileName = @"C:\temp\test.txt";
            button6.Text = System.IO.Path.GetFileName(sFileName);

        }
    }
}
