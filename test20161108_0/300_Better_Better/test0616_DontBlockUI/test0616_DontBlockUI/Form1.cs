using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Using:
using System.Threading;

namespace test0616_DontBlockUI {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnDisplayTime_Click(object sender, EventArgs e) {
            btnDisplayTime.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            Thread t = new Thread(WorkA);
            t.Start();
        }

        private void WorkA() {
            for (int i = 1; i <= 10000; i++) {
                label1.Text = i.ToString();
                // Application.DoEvents();
            }
        }

        private void WorkB() {
            for (int i = 1; i <= 10000; i++) {
                label2.Text = i.ToString();
                // Application.DoEvents();
            }
        }
        
        private void button2_Click(object sender, EventArgs e) {
            Thread t = new Thread(WorkB);
            t.Start();
        }

        private void button3_Click(object sender, EventArgs e) {
            System.Threading.Thread.Sleep(3000);
            button3.Text = "Done";
        }
    }
}
