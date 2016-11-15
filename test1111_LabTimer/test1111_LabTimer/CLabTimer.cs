using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1111_LabTimer
{
    public partial class CLabTimer : UserControl
    {
        public CLabTimer()
        {
            InitializeComponent();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    label1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        //    if (this.AtTime != null)  // 先判斷 Form1 是否有事件
        //        AtTime.Invoke(this, new EventArgs()); //呼叫事件
        //}
        public void StopStart() 
        {
            // 切換開關
            timer1.Enabled = !timer1.Enabled;
        }
        public int TimeInterval
        {
            get
            {
                return timer1.Interval;
            }
            set
            {
                if (value > 0)
                    timer1.Interval = value;
            }
        }
        // Server 事件
        public event EventHandler AtTime; //宣告事件容器
        public event TimerHandler AtTime2; //事件容器

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            if (this.AtTime != null)  // 先判斷 Form1 是否有事件
                AtTime.Invoke(this, new TimerEventArgs() { CurrentTime = DateTime.Now }); //呼叫事件
            if (this.AtTime2 != null)
                AtTime2.Invoke(this, new TimerEventArgs() { CurrentTime = DateTime.Now }); //呼叫事件
        }

    }
    
    public delegate void TimerHandler (object sender, TimerEventArgs e); //delegate 委派
    
    public class TimerEventArgs : EventArgs 
    {
        public DateTime CurrentTime { set; get; }
    }
     
}
