using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1101_MessageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KKK");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KKK","Asking");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KKK", "Asking",MessageBoxButtons.OKCancel,MessageBoxIcon.Error,MessageBoxDefaultButton.Button2   );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("KKK", "Asking", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            if (answer == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
