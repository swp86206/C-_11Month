using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test__09_Settings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 應用程式是唯讀的

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Settings.Default.DataFileName; //屬性設定成 應用程式層級...
            textBox1.Text = Properties.Settings.Default.TreceCount.ToString(); //屬性設定為使用者層級....
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //把textBox1值換掉及存到硬碟裡面去, 值隨著使用者記錄 
            // C:\Users\Mac(使用者帳號)\AppData\Local\test!!09_Settings .... 裡面的記事本
            Properties.Settings.Default.TreceCount =
                Convert.ToInt32(textBox1.Text);
            Properties.Settings.Default.Save();
        }
    }
}
