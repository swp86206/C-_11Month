using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1102_MoreContros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DateTime d = dateTimePicker1.Value;
            //button1.Text = d.ToString("yyyy-MM-dd");

            //string s = "2016-11-03";
           // string s = "July, 3,2016";
           //   DateTime d = Convert.ToDateTime(s);
           //DateTime d = DateTime.Parse(s);  //用Parse 轉

            DateTime d = DateTime.Today;
            //this.Text = Convert.ToInt32(d.DayOfWeek).ToString(); //取得星期幾
            this.Text = d.DayOfWeek.ToString();
            // d = d.AddDays(100); // 一百天以後
            button1.Text = d.ToString("yyyy-MM-dd");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //上網找農曆程式碼
           DateTime now = DateTime.Now;
            
            System.Globalization.TaiwanLunisolarCalendar tc = new System.Globalization.TaiwanLunisolarCalendar();
            DateTime d = DateTime.Today;
            //button2.Text = tc.GetYear(d).ToString(); // 農曆幾年
            //button2.Text = tc.GetMonth(d).ToString();  // 農曆幾月
            //button2.Text = tc.GetDayOfMonth(d).ToString(); // 農曆幾號
            // button2.Text = tc.GetDayOfWeek(d).ToString();  //星期幾
            //button2.Text = tc.GetYear(d).ToString() + "-" +tc.GetMonth(d).ToString() + "-" +tc.GetDayOfMonth(d).ToString() ;  //顯示今天農曆年月日
            
           // 另一寫法,顯示今天農曆年月日, 持續....
            // button2.Text = tc.ToDateTime("Int32 year","int32 month","int32 day","int32 hour","int32 minute","int32 second","int32 millisecond").ToString();
            //button2.Text = Convert.ToDateTime(tc).ToString();
            button2.Text = tc.Eras.ToString()
        }        

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = monthCalendar1.SelectionStart.ToString("D");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = numericUpDown1.Value.ToString();

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.Text = hScrollBar1.Value.ToString();
        }
    }
}
