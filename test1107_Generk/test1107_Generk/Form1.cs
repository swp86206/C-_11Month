using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1107_Generk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 通用
            int x = 100;
            int y = 200;

            // 引用時需告知 T 的資料型別
            Swap<int>(ref x, ref y);
            button1.Text = string.Format("x = {0}, y = {1}", x ,y );

        }

        // 寫一個通用類別T
        private static void Swap<T>(ref T x,ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = 100.1;
            double y = 200.2;
            
            Swap<double>(ref x, ref y);
            button2.Text = string.Format("x = {0}, y = {1}", x, y);
        }
    }
}
