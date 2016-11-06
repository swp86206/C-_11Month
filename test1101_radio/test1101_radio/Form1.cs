using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1101_radio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var answer = -1;
            if (radioButton1.Checked)
                answer = 1;
            else if (radioButton2.Checked)
                answer = 2;
            else if (radioButton3.Checked)
                answer = 3;
            button1.Text = answer.ToString(); 
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }

        private void doClick(object sender, EventArgs e)
        {
            // this.Text = (sender as RadioButton).Tag.ToString();
            groupBox1.Tag = (sender as RadioButton).Tag; //用Tag 記資料
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = groupBox1.Tag.ToString();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                radioButton5.ImageIndex = 5;
            }
            else
            {
                radioButton5.ImageIndex = 2;
            }              
          
        }
    }
}
