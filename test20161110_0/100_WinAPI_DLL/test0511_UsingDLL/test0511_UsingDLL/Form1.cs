using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace test0511_UsingDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("test0506DLL.dll")]
        extern static int Add2(int x);

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = Add2(3).ToString();
        }
    }
}
