using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1114_TestWS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webService1.Timeout = 10000; // 要求在限定時間內拿到資料,否則出現錯誤
            webService1.CookieContainer = new System.Net.CookieContainer(); // CookieContainer:一個專門裝cookie 的資料袋
            webService1.Credentials = new System.Net.NetworkCredential("test","test1114");  //Credentials :告知Server 端帳號密碼
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try { 
            //button1.Text = webService1.Add(3, 5).ToString();
            //}
            //catch (System.Net.WebException ex)
            //{
            //    button1.Text = ex.Message;
            //}

           // button1.Text = webService1.Add(3, 5).ToString();

            webService1.AddAsync(3, 5, button1); //button1 為物件參考(object UserState),附帶資訊
            button1.Text = "1_Processing .....";
        }

        private void webService1_AddCompleted(object sender, localhost.AddCompletedEventArgs e)
        {
            //this.Text = e.UserState.ToString();
            //button1.Text = e.Result.ToString();

            Button btn = e.UserState as Button; // 事件e 的UserState 是一個物件  //e.UserState  是一個object型態的物件  當我們確定它可以等於一個button時，就可以用as來轉型; 語法上(e.UserState as button) 會回傳一個button型態的物件 所以要用一個空的button來接它
            btn.Text = e.Result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webService1.AddAsync(1, 2,button2); //button2 為物件參考(object UserState),附帶資訊
            button2.Text = "2_Processing .....";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Text = webService1.SetData("QQQ","KK12");
            button3.Text = webService1.GetData("QQQ"); // 要有 CookieContainer 才會顯示值
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = webService1.GetData("QQQ");
        }
    }
}
