using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1108_Drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            this.BackColor = Color.Gray;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackColor = Color.FromArgb(192, 192, 192);
            button1.Location = new Point(10, 100); // button1 移動位置
            */

            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Red, 7); //粗細
            //p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; // 線的樣式  //虛線
            //p.StartCap = System.Drawing.Drawing2D.LineCap.Round; //起點樣式   //圓弧
            p.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor; //起點樣式   //圓頭
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;  // 終點樣式  // 箭頭
            
            g.DrawLine(p, 1, 1, 100, 100);

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Pen p = new Pen(Color.Maroon, 2);

            Point[] points = new Point[] {new Point(10, 10),
                                          new Point(10, 100),
                                          new Point(50, 65),
                                          new Point(100, 100),
                                          new Point(85, 40)};
            //Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(
            //    new Point(25, 25), new Point(50, 50), Color.White, Color.Red);

            g.FillPolygon(new SolidBrush(Color.Aqua),points); // 面塗滿
            //g.FillPolygon(b, points); // 這是面
            //g.DrawPolygon(p, points); // 這是線

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Pen p = new Pen(Color.Maroon, 2);

            Point[] points = new Point[] {new Point(10, 10),
                                          new Point(10, 100),
                                          new Point(50, 65),
                                          new Point(100, 100),
                                          new Point(85, 40)};
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Point(1, 1), new Point(100, 100), Color.White, Color.Red);

            g.FillPolygon(b, points); // 這是面
            g.DrawPolygon(p, points); // 這是線
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Pen p = new Pen(Color.Red, 7); //粗細
            ////p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; //虛線
            //p.StartCap = System.Drawing.Drawing2D.LineCap.Round; //圓頭
            //p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;  // 箭頭

            //g.DrawLine(p, 1, 1, 100, 100);
        }
    }
}
