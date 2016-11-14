using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1109_DrawLine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point StartPoint;
        bool bHoldMouse = false; //追蹤滑鼠是否有按著
       // List<Point> points = new List<Point>(); // 紀錄滑鼠軌跡點，使用 List 資料結構
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // 起點 開始畫線
            StartPoint = new Point(e.X, e.Y);
            bHoldMouse = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //開始畫線
            if (bHoldMouse) { 
            Point CurrentPoint = new Point(e.X, e.Y);
            Graphics g = this.CreateGraphics();
                g.DrawLine(Pens.DarkRed, StartPoint, CurrentPoint);
              
            }
            //if (isMouseDown)
            //{
            //    points.Add(e.Location);
            //    this.Invalidate(); // 在滑鼠移動的時候，不斷的即時更新畫面
            //}
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //終點
            bHoldMouse = false;
            Point EndPoint = new Point(e.X, e.Y);

            Graphics g = this.CreateGraphics(); //造Graphics物件
            g.DrawLine(Pens.DarkRed, StartPoint, EndPoint);  //在 Graphics 上作畫  // pens 複數型
            
        }
    }
}
