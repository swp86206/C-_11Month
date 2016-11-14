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
    public partial class Solution_2 : Form {
        public Solution_2() {
            InitializeComponent();
        }
        /**--------- 解法說明-----------
         *  考慮閃爍的成因:
         *  當一圖形被擦去並重新繪製，期間一定會有一小段空白
         *  當擦去並重繪的動作夠快時，人眼未必會察覺閃爍(如日光燈)
         *  得出可能的解決方法:
         *  1:將重繪間隔縮短。(這個我不知道怎麼做，我猜系統在預設上已經快到不能再快了。)
         *  2:不要讓空白出現。(換句話說，就是用覆蓋的方式取代擦去並重繪)
         *  本程式採用解2:覆蓋 的方式來規避空白出現。
         *  
         *  其他說明:
         *  1.實際上在最初版本中全部都是用bitmap來完成覆蓋的動作，結果在測試期間出現
         *      記憶體不足的錯誤(隨便都破G)，經過一連串的測試後猜測是因為bitmap儲存了太多資訊。
         *      於是在最終版本採用轉存成jpeg的方式來當成覆蓋用圖片，確實解決了記憶體的問題，
         *      但是也衍生了會跑色這個問題，也許還有其他問題。
         *  2.因為bitmap有透明屬性，如果不塗上背景色，想被蓋去的圖將仍為可見狀態，塗上背景色解決
         *      了該問題，但在後來產生了(1.)中所述問題。並且經嘗試，透明區域在轉為jpeg時會被當成黑色
         *      (RGB皆為0)，因此不管是使用Bitmap還是jpeg作為覆蓋圖，都要先塗上正確的底色。
         */

        bool bMouseDown = false;     //用來記錄滑鼠按下與否。

        Point startPoint, currentPoint, endPoint;       //開始點、中繼點、終點

         //List<Point[]> pointList = new List<Point[]>();    //目前沒用到，當加入編輯模式時，會需要將每條線分別存取，可以考慮使用這個變數。

        Image imgFinal;     //用來繪製在form上的圖片。

        /// <summary>
        /// 此函式將bmp轉為jpeg並由img接收。
        /// </summary>
        /// <param name="bmp">來源bmp</param>
        /// <param name="img">接收jpeg的Image變數。注意，這個變數值將會被改寫。</param>
        private void bmpToJpeg(Bitmap bmp, ref Image img) {
            //以下是目前找到比較快的轉檔方式
            //想法: bmp --轉存--> jpeg --指定--> img

            //MemoryStream 記憶體資料流，會用他是因為Bitmat的save方法支援將點陣圖(bmp)轉為特定格式並寫入stream。
            System.IO.MemoryStream ms = new System.IO.MemoryStream();   

            //將bmp轉為jpeg並寫入資料流。
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            //指定img為一資料流中的資料。
            img = Image.FromStream(ms);
            ms.Close();
        }

        private void Form3_Load(object sender, EventArgs e) {
            /**
             *  1.建立一個大小與form相同的bitmap畫布(Graphics)，先刷底色=背景色。
             *  2.將刷好的bitmap轉為繪製在form上的圖片(image)。
             *  3.將image繪製在form上面。
             */
            Bitmap bm = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, bm.Width, bm.Height);
            bmpToJpeg(bm, ref imgFinal);
            g = this.CreateGraphics();
            g.DrawImage(imgFinal, 0, 0);
            bm.Dispose();
            g.Dispose();
        }

        // 使用Resize事件的原因:
        // 1.當視窗被縮小時，畫過的痕跡會被破壞(抹除)，需要重繪。
        // 2.且，一開始的畫布(Graphics)不夠大，需要在Resize事件建立將畫布擴大的方法。
        private void Form3_Resize(object sender, EventArgs e) {
            /**
             *   1.建立一個空白畫布，大小為目前視窗或是繪製用圖片(imgFinal)之較大者。
             *   2.刷底色
             *   3.刷圖片(imgFinal)
             *   4.將圖片繪製在form上
             */
            Bitmap bm = new Bitmap(Math.Max(this.Width, imgFinal.Width), Math.Max(this.Height, imgFinal.Height));
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, bm.Width, bm.Height);
            g.DrawImage(imgFinal, 0, 0);
            bmpToJpeg(bm, ref imgFinal);
            g.Dispose();
            g = this.CreateGraphics();
            g.DrawImage(imgFinal, 0, 0);
            g.Dispose();
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e) {
            /**
             *  1.紀錄滑鼠為按下(bMouseDown = true)
             *  2.指定目前游標位置(e.Location)為開始點
             */
            bMouseDown = true;
            startPoint = e.Location;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e) {
            /**
             *  當滑鼠為按下時進入
             *  1.指定目前游標位置(e.Location)為中繼點。
             *  2.以繪製用圖片(imgFinal)為基底建立一個新畫布
             *  3.在該畫布上畫上開始點到中繼點的線段
             *  4.將該畫布繪製在form上
             *  注意:這裡不將畫布回存給繪製用圖片(imgFinal)
             */
            if (bMouseDown) {
                currentPoint = e.Location;  //1
                Bitmap bm =new Bitmap(imgFinal);    //2
                Graphics g = Graphics.FromImage(bm);
                g.DrawLine(Pens.DarkRed, startPoint, currentPoint);     //3
                g= this.CreateGraphics();       //4
                g.DrawImage(bm, 0, 0);
                bm.Dispose();
                g.Dispose();
            }
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e) {
            /**
             *  1.紀錄滑鼠沒有按下(bMouseDown = false)
             *  2.將繪製用圖片(imgFinal)當成畫布
             *  3.畫上開始點到終點點的線段
             *  4.將畫布繪製在form上
             */
            bMouseDown = false;     //1
            endPoint = e.Location;     //指定游標位置為終點，這行其實是多餘的
            Graphics g = Graphics.FromImage(imgFinal);      //2
            g.DrawLine(Pens.DarkRed, startPoint, endPoint);     //3
            g = this.CreateGraphics();      //4
            g.DrawImage(imgFinal, 0, 0);
            g.Dispose();
        }
    }
}
