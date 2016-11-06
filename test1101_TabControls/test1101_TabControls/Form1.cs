using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1101_TabControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedIndex = 1;
            //button1.Text = this.tabControl1.SelectedIndex.ToString();
            int test = this.tabControl1.SelectedIndex;
            this.tabControl1.TabPages[test].Text = "Page X";
            
        }
    }
}
