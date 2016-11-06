using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test1104_night
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;  //宣告圖形物件 (點陣圖)
        int oldX, oldY;  // 記滑鼠游標用
        int PenPoint;   //記畫筆粗細用
        Color PenColor;  // 記畫筆顏色用

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)  
        {
            // 程式載入時~
            bmp = new Bitmap(320, 210); //建立點陣圖大小
            Graphics g = Graphics.FromImage(bmp); // 建一個畫布 g,並把點陣圖放進去
            PenColor = Color.Black;  // 預設畫筆顏色為黑色
            PenPoint = 3;  //預設畫筆大小為 3畫素
            g.Clear(Color.White);  //將畫布清為白色
            pictureBox1.Image = bmp;  //將點陣圖貼到此控制項上
            pictureBox1.Refresh(); // 更新

        }

        private void 開檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream f = new FileStream("myPic.jpg", FileMode.Open); // 打開bin/Debug 裡面的myPic.jpg 並放到f
                bmp = new Bitmap(f); //把f 放到點陣圖
                f.Close();
                pictureBox1.Image = bmp;  //將點陣圖貼到此控制項上
            }
            catch (Exception ex)
            {
                MessageBox.Show("目前專案無圖檔,請先繪圖後再存檔");

            }
        }

        private void 存檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmp.Save("myPic.jpg");  //存到此圖裡
        }

        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp); // 建一個畫布 g,並把點陣圖放進去
            g.Clear(Color.White); // 將畫布清為白色
            pictureBox1.Image = bmp; // 將點陣圖貼到此控制項上
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //停止應用程式
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // 當滑鼠點下去時的X,Y 座標記錄到 oldX 與 oldY 中
            oldX = e.X;  
            oldY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // 如果偵測到點滑鼠左鍵
            {
                Graphics g = Graphics.FromImage(bmp); // 建一個畫布 g,並把點陣圖放進去
                Pen p = new Pen(PenColor, PenPoint);  // 定義繪製直線與曲線的物件 (定義顏色及畫筆大小)
                g.DrawLine(p, oldX, oldY, e.X, e.Y); //連接兩點的直線
                pictureBox1.Image = bmp;  // 將點陣圖貼到此控制項上
                // ↓↓↓  將目前畫筆座標當作下次下次畫筆的起點 
                oldX = e.X;   
                oldY = e.Y;
            }
        }

        private void ptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenPoint = 1;  //設定畫筆粗細為 1pt 
        }

        private void ptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PenPoint = 3;//設定畫筆粗細為 3pt 
        }

        private void ptToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PenPoint = 5;//設定畫筆粗細為 5pt 
        }

        private void 黑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenColor = Color.Black; //設畫筆顏色為黑色
        }

        private void 紅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenColor = Color.Red; //設畫筆顏色為紅色
        }

        private void 綠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenColor = Color.Green; //設畫筆顏色為綠色
        }

        private void 藍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenColor = Color.Blue; //設畫筆顏色為藍色
        }

       

        

    }
}
