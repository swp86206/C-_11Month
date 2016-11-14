using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace test1110_Transpant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // WINAPI Constants
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_Trnasparent = 0x20;
        private const int LWA_ALPHA = 2;

        // WINAPI Functions
        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        public static void ApplyTransparency(IntPtr Handle, byte Transparency)
        {
            
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_Trnasparent);
            SetLayeredWindowAttributes(Handle, 0, Transparency, LWA_ALPHA);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            // 按鍵點下去,會整個透下去,直接操作下面的頁面,本來的則不能操作
            ApplyTransparency(this.Handle, 155); // 選擇透明度 (0:看不到, 255: 沒透明)
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE)& (~WS_EX_LAYERED)&(~WS_EX_Trnasparent)); // 去掉  (~WS_EX_LAYERED), (~WS_EX_Trnasparent)
            timer1.Enabled = false;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 自己練習玩玩
            //  private const int WS_EX_Trnasparent = 0x20;

            byte test = (byte)WS_EX_Trnasparent;
            // test = (byte)(test << 1);
            // test = (byte)(test >> 3);

            // and:
            // test = (byte)(test & 10);
            /*
              100000
            & 001010
            --------
              000000
            */

            // or:
            // test = (byte)(test | 10);
            /*
              100000
            | 001010
            --------
              101010
            */

            // xor:
            // test = (byte)(test ^ 10);
            /*
              100000
            ^ 001010
            --------
              101010
            */
            test = (byte)(test ^ 10);
            /*
              101010
            ^ 001010
            --------
              100000
            */

            this.Text = Convert.ToString(test, 2);
        }
    }
}
