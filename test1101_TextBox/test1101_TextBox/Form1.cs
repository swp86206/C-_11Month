using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1101_TextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox6.Focus();
            //textBox6.SelectionStart = 0;
            //textBox6.SelectionLength = 3;
            textBox6.SelectionStart = textBox6.TextLength;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Focus();
            SendKeys.Send("中文123");
            SendKeys.Send("{Home}+{Right}+{Right}^c");
            SendKeys.Send("{End}^v");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad"); // 打開記事本
            System.Threading.Thread.Sleep(5000); //0.3 秒
            SendKeys.Send("中文123");
            SendKeys.Send("{Home}+{Right}+{Right}^c");
            SendKeys.Send("{End}^v");
            SendKeys.Send("%f{down}{down}{enter}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
            System.Threading.Thread.Sleep(2000);
            SendKeys.Send("{TAB}");
            System.Threading.Thread.Sleep(2000);
            SendKeys.Send("+{TAB}");
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if(e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{tab}");
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            textBox8.SelectionLength = 1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{tab}");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad");
        }
    }
}
