using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0611_UsingWebService {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            button2.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            // button1.Text = ws.Add(2, 6).ToString();
            ws.AddAsync(2, 7);
            button1.Text = "Processing...";
        }

        
        private void ws_AddCompleted(object sender, localhost.AddCompletedEventArgs e) {
            button1.Text = e.Result.ToString();
        }
    }
}
