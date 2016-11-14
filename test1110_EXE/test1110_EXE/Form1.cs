using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test1110_DLL;

namespace test1110_EXE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 靜態方法可直接使用
            button1.Text = CTest.GetTime();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 非靜態方法, 需造一個物件
            string sName = "Chien";
            CTest obj = new CTest();
            button2.Text = obj.Hello(sName);
        }
    }
}
