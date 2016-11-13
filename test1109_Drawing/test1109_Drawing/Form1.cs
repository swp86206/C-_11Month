using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace test1109_Drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics G = this.CreateGraphics();

            Rectangle R = new Rectangle(new Point(40, 40), new Size(280, 280)); //new Rectangle 造一個矩形區域 ,從(40, 40) 開始
            Font fTest = new Font(new FontFamily("Arial"), 50);

            StringFormat F1 = new StringFormat(StringFormatFlags.NoClip);  //StringFormat  NoClip 不要裁切
            StringFormat F2 = new StringFormat(F1);
            F1.LineAlignment = StringAlignment.Near;  // LineAlignment Y 方向(上下)  // Near 是 left // 靠近樞紐較近處 
            F1.Alignment = StringAlignment.Center; // 置中對齊  // Alignment X 方向(左右)
           // F2.LineAlignment = StringAlignment.Center;
            //F2.Alignment = StringAlignment.Far; // Far 是 Right  // 靠近樞紐較遠處
            F2.LineAlignment = StringAlignment.Far;
            F2.Alignment = StringAlignment.Center;
            F2.FormatFlags = StringFormatFlags.DirectionVertical; //轉90度 : LineAlignment --->  Alignment


            G.DrawRectangle(Pens.Black, R); //畫出四方型區域
            G.DrawString("Hello", fTest, Brushes.Blue, new Point(10, 100)); // 在10,100畫一段文字
            G.DrawString("Hello", this.Font, Brushes.Blue, new Point(this.Width / 2, 100)); //置中
            G.DrawString("Format1", this.Font, Brushes.Red, R, F1);
            G.DrawString("Format2", this.Font, Brushes.Red, R, F2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           //  SolidBrush (實心畫刷)、LinearGradientBrush (線性化刷), TextureBrush (材質畫刷)
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            SolidBrush brushWhite = new SolidBrush(Color.White);
            g.FillRectangle(brushWhite, 0, 0,
            this.ClientSize.Width, this.ClientSize.Height);

            FontFamily fontFamily = new FontFamily("Arial");
            StringFormat strformat = new StringFormat();
            string szbuf = "Text Designer";

            GraphicsPath path = new GraphicsPath();
            path.AddString(szbuf, fontFamily,
            (int)FontStyle.Regular, 48.0f, new Point(10, 10), strformat);
            Pen pen = new Pen(Color.FromArgb(234, 137, 6), 1);
            g.DrawPath(pen, path);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 255)); // SolidBrush 實心畫刷
            //g.FillPath(brush, path);

            brushWhite.Dispose();
            fontFamily.Dispose();
            path.Dispose();
            pen.Dispose();
            brush.Dispose();
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image I = Image.FromFile(@"c:\temp\test.jpg");
            this.BackgroundImage = I;


            // 似於在記憶體(Bitmap)上作畫
            Bitmap Bm = new Bitmap(110, 110);  //Bitmap 把圖形看成是一個一個光點構成的地圖,每一個光點代表一個畫素,每一個畫素用綠色來色紅色註記,每個畫素3個byte
            Graphics G = Graphics.FromImage(Bm); // 透過Graphics的FromImage方法,造出G物件,再G物件上作圖而直接操作在 Bitmap 上
            G.FillRectangle(new SolidBrush(Color.Wheat), 0, 0, 110, 110); //填入四方型區域 (背景色)

            Point[] points = new Point[] {new Point(10, 10),   // 準備一個陣列
                                          new Point(10, 100),
                                          new Point(50, 65),
                                          new Point(100, 100),
                                          new Point(85, 40)};
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(  // 準備一個畫刷
                new Point(1, 1), new Point(100, 100), Color.White, Color.Red); // 白 --> 紅 , 漸層

            G.FillPolygon(b, points);  // 用畫刷b 填一個多邊形區域 (points)   填入一個多邊形區域 (紅色多邊形)
            Bm.Save(@"c:\temp\test2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg); // bitmap 可以存成其他主流格式
            
            /* 在空網站輸出 
            Response.ContentType="image/jpg"; //告知瀏覽器此為圖片不要當網頁處理,Chrome 瀏覽器就不會看到亂碼
            Bm.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.End();
            */
        }
    }
}
