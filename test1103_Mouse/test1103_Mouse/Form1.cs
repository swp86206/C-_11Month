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

namespace test1103_Mouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //this.Text = DateTime.Now.ToString();
            Debug.WriteLine("MouseDown");
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("MouseUp");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("MouseClick");
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("MouseDoubleClick");
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //this.PointToClient()
            //this.PointToScreen()
        

            button1.Text = string.Format("{0},{1}",
                                      e.X, e.Y);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            //button1.PointToClient()
            //button1.PointToScreen()   
            Point ptScreen = button1.PointToScreen(new Point(e.X, e.Y)); //將button1 的座標轉成螢幕座標

            Point prFprm = this.PointToClient(ptScreen); //將button1的全螢幕座標轉成工作區(表單)座標

            this.Text = string.Format("{0},{1}",
                                      prFprm.X, prFprm.Y);
        }
    }
}
