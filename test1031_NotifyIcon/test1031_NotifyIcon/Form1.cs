using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1031_NotifyIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            
            timer1.Enabled = true;
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Show();
            //this.BringToFront();
            timer1.Enabled = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                //this.Text = DateTime.Now.ToString();
                this.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(3000);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void iten1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }
    }
}
