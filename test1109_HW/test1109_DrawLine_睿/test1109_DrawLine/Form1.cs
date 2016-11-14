using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1109_DrawLine {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        Bitmap bm1;
        Bitmap bm2;
        Point StartPoint;
        bool bHoldMouse = false;
        //bool iTimer = false;
        

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            StartPoint = new Point(e.X, e.Y);
            bHoldMouse = true;
            //iTimer = true;
            //bm2 = bm1;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            bm2 = new Bitmap(bm1);
            if (bHoldMouse) {
                Point CurrentPoint = new Point(e.X, e.Y);
                Graphics g = Graphics.FromImage(bm2);
                //g.Clear(Color.WhiteSmoke);
                g.DrawLine(Pens.DarkRed, StartPoint, CurrentPoint);
                this.BackgroundImage = bm2;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            bHoldMouse = false;
            //iTimer = false;
            Point EndPoint = new Point(e.X, e.Y);

            Graphics g = Graphics.FromImage(bm1);
            g.DrawLine(Pens.DarkRed, StartPoint, EndPoint);
            this.BackgroundImage = bm1;
            bm2.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         bm1 = new Bitmap(this.Width, this.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (iTimer == true) {
            //    Graphics g = CreateGraphics();
            //    g.Clear(Color.White);
            //}
        }
    }
}
