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

namespace test0611_Transparency {
    public partial class Form1 : Form {
        
        
        public Form1() {
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

        public static void ApplyTransparency(IntPtr Handle, byte Transparency) {
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_Trnasparent);
            SetLayeredWindowAttributes(Handle, 0, Transparency, LWA_ALPHA);
        }


        private void button1_Click(object sender, EventArgs e) {
            this.TopMost = true;
            ApplyTransparency(this.Handle, 200);
        }
    }
}


