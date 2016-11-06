using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace test1103_Keyboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int UpOrDown = 0;
        int LeftOrRight = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("Form keydown :" + e.KeyCode);
            //if (e.Control && e.KeyCode == Keys.Down)
            //    pictureBox1.Top += 10;
            //else if (e.Control && e.KeyCode == Keys.Up)
            //    pictureBox1.Top -= 10;
            //else if (e.Control && e.KeyCode == Keys.Left)
            //    pictureBox1.Left -= 10;
            //else if (e.Control && e.KeyCode == Keys.Right)
            //    pictureBox1.Top += 10;

            if (e.KeyCode == Keys.Down)
                UpOrDown = 10;
            if (e.KeyCode == Keys.Up)
                UpOrDown = -10;
            if (e.KeyCode == Keys.Right)
               LeftOrRight = 10;
            if (e.KeyCode == Keys.Left)
                LeftOrRight = -10;


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("Form up :" + e.KeyCode);

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                UpOrDown = 0;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                LeftOrRight = 0;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("Form Keypress :" + e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i =1; i<=1000; i++)
            {
                label1.Text = i.ToString();
                for (int j=1; j <= 10000; j++)
                {
                    ;
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("textBox keydown :" + e.KeyCode);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("txtBox Keypress :" + e.KeyChar);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("txtBox up :" + e.KeyCode);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top += UpOrDown;
            pictureBox1.Left += LeftOrRight;
        }
    }
}
