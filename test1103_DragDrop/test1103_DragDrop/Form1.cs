using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1103_DragDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // 1. source.DrDragDrop()
            textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void label1_DragOver(object sender, DragEventArgs e)
        {
            this.Text = DateTime.Now.ToString();
            e.Effect = DragDropEffects.Move; //可以接受Move

        }

        private void textBox2_DragOver(object sender, DragEventArgs e)
        {
            // new TextBox
            // set it's AllowDrop = true
            // write DragOver Event-Handler
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;  
            
            
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            string txtContent = e.Data.GetData(DataFormats.Text).ToString();
            textBox2.Width = 250;
            textBox2.Text = txtContent;
        }
    }
}
