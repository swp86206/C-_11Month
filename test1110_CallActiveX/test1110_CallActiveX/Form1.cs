using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1110_CallActiveX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string s = "Test Text";

            //RH.MD5 obj = new RH.MD5();
            //textBox1.Text = obj.DigestStrToHexStr(s);

            string sSource = textBox1.Text;
            RH.MD5 obj = new RH.MD5(); //雜湊  // 事先註冊 VB6 形成的 
            string result = obj.DigestStrToHexStr(sSource);
            textBox2.Text += result + Environment.NewLine;

        }
    }
}
