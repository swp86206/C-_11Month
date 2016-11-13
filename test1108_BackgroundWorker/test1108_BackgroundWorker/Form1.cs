using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1108_BackgroundWorker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // private bool bCancel = false;

        // 啟動但不偵錯 Run

        private void button1_Click(object sender, EventArgs e)
        {
            //bCancel = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // 在背景執行比較耗時費工的程式,好讓其他程式得以順利執行
            for (int i = 1; i <= 100000; i++)
            {
                button1.Text = i.ToString();
                //if (bCancel)
                //    break;

                if (backgroundWorker1.CancellationPending)  // 按button3 鍵 CancellationPending 為true 值 --> break
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // bCancel = true;
             backgroundWorker1.CancelAsync(); // 呼叫CancelAsync 方法,.設定 WorkerSupportsCancellation 屬性為true值<代表使用此方法> , 按button3 鍵 CancellationPending 為true 值 --> break
        }
    }
}
