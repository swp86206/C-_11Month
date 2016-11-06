using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1102_MDI
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }
        public void save()
        {
            MessageBox.Show("ChildForm Saved.");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Text);
        }
    }
}
