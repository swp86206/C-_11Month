using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1031_TwoForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            //frm.Show();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                loginButton.Text = frm.userNameTextBox.Text;
            }
            else
            {
                loginButton.Text = "Cancel";
            }
        }
    }
}
