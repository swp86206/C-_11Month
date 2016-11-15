using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test1111_LabTimer;

namespace test1111_usingLabTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cLabTimer2.StopStart();
        }

        private void cLabTimer1_AtTime(object sender, EventArgs e)
        {
            //this.Text = DateTime.Now.ToString();
            

            //因沒被委派,所以使用根事件名稱(EventArgs),若要使用TimerEventArgs,則須將 e 轉型成另外一個事件資料
            TimerEventArgs args = e as TimerEventArgs; // 原本的e 是最原始的,沒有事件資料,故將 e 轉型成TimerEventArgs 事件資料,以使用其事件
            this.Text =args.CurrentTime.ToString();

        }

        private void cLabTimer1_AtTime2(object sender, test1111_LabTimer.TimerEventArgs e)
        {
            // 委派過後的事件不是使用根事件(EventArgs),而是使用委派後的事件容器名稱(TimerEventArg)
            this.Text =e.CurrentTime.ToString();
        }
    }
}
