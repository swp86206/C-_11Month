using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1109_Painting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        int iPageCount = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            iPageCount++;
            if(iPageCount == 1)  //如果在第一頁
            {

                Graphics g = e.Graphics;  //         this.CreateGraphics();

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




                e.HasMorePages = true; // 還有下一頁
            }else if(iPageCount == 2)
            {
                Graphics G = e.Graphics; // this.CreateGraphics();

                Rectangle R = new Rectangle(new Point(40, 40), new Size(280, 280));

                StringFormat F1 = new StringFormat(StringFormatFlags.NoClip);
                StringFormat F2 = new StringFormat(F1);
                F1.LineAlignment = StringAlignment.Near;
                F1.Alignment = StringAlignment.Center;
                F2.LineAlignment = StringAlignment.Center;
                F2.Alignment = StringAlignment.Far;
                F2.FormatFlags = StringFormatFlags.DirectionVertical;

                G.DrawRectangle(Pens.Black, R);
                G.DrawString("Format1", this.Font, Brushes.Red, R, F1);
                G.DrawString("Format2", this.Font, Brushes.Red, R, F2);

                e.HasMorePages = false; // 沒有下一頁了
            }
        }
    }
}
