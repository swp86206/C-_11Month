using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_161109_DrawLineWithMouse {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            new Solution_1().Show();
        }


        private void button2_Click(object sender, EventArgs e) {
            new Solution_2().Show();
        }
    }
}
