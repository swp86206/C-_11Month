using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1101_listbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //listBox2.Text = listBox1.SelectedItems.Count.ToString();
            //button1.Text = listBox1.SelectedItems[1].ToString();

            // Copy items
            for (int i = 0;i < listBox1.SelectedItems.Count; i++)
            {
                string data = listBox1.SelectedItems[i].ToString();
                if(listBox2.Items.IndexOf(data) < 0)  //not found
                listBox2.Items.Add(data);
            }

            //Delete items if needed.
            if (moveRadioButton2.Checked)
            {
                // delete selected items
                for (int i = listBox1.SelectedItems.Count -1; i >= 0; i--) // 從最大的開始刪,由後往前刪
                {
                    string data = listBox1.SelectedItems[i].ToString();
                    listBox1.Items.Remove(data);
                }
            }


        }
    }
}
