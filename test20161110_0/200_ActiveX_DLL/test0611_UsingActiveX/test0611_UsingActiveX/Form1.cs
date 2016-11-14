using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0611_UsingActiveX {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            RH.MD5 obj = new RH.MD5();
            // button1.Text = obj.DigestStrToHexStr("Yahoo+Chien+1234");
            // button1.Text = obj.DigestStrToHexStr("Amazon+Wolfgang+1234");
            button1.Text = obj.DigestStrToHexStr("Ivy+Wolfgang+Bill");
        }
    }
}
