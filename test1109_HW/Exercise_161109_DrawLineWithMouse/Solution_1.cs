using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_161109_DrawLineWithMouse {
    public partial class Solution_1 : Form {
        public Solution_1() {
            InitializeComponent();
        }
        /**--------- 解法說明-----------
         *  1.程式碼本身與不會閃爍沒有任何關係
         *  2.此解法關鍵在於表單的雙重緩衝是否開啟
         *  關於雙重緩衝(Double Buffering):
         *  http://e-troy.blogspot.tw/2015/01/c-picturebox.html
         */
        bool bMouseDown = false;     //用來記錄滑鼠按下與否。

        List<Point[]> lLine = new List<Point[]>();      //用來儲存目前已經畫過的所有線的起點及終點

        Point startPoint, currentPoint, endPoint;       //開始點、中繼點、終點

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            /**
             *  1.紀錄滑鼠為按下(bMouseDown = true)
             *  2.指定目前游標位置(e.Location)為開始點
             */
            bMouseDown = true;
            startPoint = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            /**
             *  當滑鼠為按下時進入
             *  1.指定目前游標位置(e.Location)為中繼點。
             *  2.叫用表單的Refresh( )方法，該方法呼叫後會觸發Form1_Paint事件
             */
            if (bMouseDown) {
                currentPoint = e.Location;
                this.Refresh();
                // this.Invalidate();  
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            /**
             *   1.紀錄滑鼠沒有按下(bMouseDown = false)
             *   2.指定游標位置為終點
             *   3.將目前最新的開始點及終點加入lLine
             */
            bMouseDown = false;
            endPoint = e.Location;
            lLine.Add(new Point[] { startPoint, endPoint });
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            /**
             *  1.檢查:當lLine的count屬性不為0(即目前已經存入任意數量的線段)
             *  1-1 則:將 lLine內的點座標逐個取出，並以DrawLine方法繪製在form上
             *  2.檢查:當滑鼠按下(即目前為MouseMove事件)
             *  2-2 則:以DrawLine方法將開始點與中繼點相連線段繪製在form上
             */
            if (lLine.Count != 0) {     //1
                for (int i = 0; i < lLine.Count; i++) {     //1-1
                    Graphics g = e.Graphics;
                    g.DrawLine(Pens.DarkRed, lLine[i][0], lLine[i][1]);
                }
            }
            if (bMouseDown) {       //2
                Graphics g = e.Graphics;        //2-1
                g.DrawLine(Pens.DarkRed, startPoint, currentPoint);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            //設置雙重緩衝啟用與否
            this.DoubleBuffered = checkBox1.Checked;
        }
    }
}
