using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1101_ClipboardMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string lastContent = ""; // 先把上次資料記下來

        private void button1_Click(object sender, EventArgs e)
        {
            // textBox1.Text += "New Conetnt" + System.Environment.NewLine + System.Environment.NewLine;
            // textBox1.Text += Clipboard.GetText() + System.Environment.NewLine; //抓到剪貼簿
            // 用Timer 作偵測剪貼簿是否有新內容

            //  Clipboard.Clear();
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string content = Clipboard.GetText();
            if (lastContent != content)  //判斷資料是否一樣
            {
                textBox1.Text += content  
                + System.Environment.NewLine
                + System.Environment.NewLine;
                lastContent = content;  // 資料在再保留
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }
    }
}
