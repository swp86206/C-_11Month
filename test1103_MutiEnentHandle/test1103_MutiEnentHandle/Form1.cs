using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1103_MutiEnentHandle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += Btn_Click;
        }

       

        int iTh = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            iTh++;  //為使新增的不要在原位置,故累計加一
            Button btn = new Button();
            
            btn.Top = button1.Top + iTh*button1.Height + 10;
            btn.Left = button1.Left;
            btn.Width = button1.Width;
            btn.Height = button1.Height;
            btn.Text = "Test";

            this.Controls.Add(btn);
            btn.Click += button1_Click; //新增的在原位子

            //btn.Click += Btn_Click; //按tab鍵,產生事件  +=代表有事件增加
            //btn.Click += Btn_Click;
            //btn.Click += SayHello;
            //btn.Click -= Btn_Click; // -= 代表減少一個事件,使其沒有發生
        }

        private void SayHello(object sender, EventArgs e)
        {
            MessageBox.Show("Hello !");
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
