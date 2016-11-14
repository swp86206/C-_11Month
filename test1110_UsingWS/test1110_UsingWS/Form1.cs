using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1110_UsingWS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //localhost.WebService obj = new localhost.WebService();
            //button1.Text = obj.Add(10, 15).ToString();

            button1.Text = webService1.Add(3, 5).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           button2.Text = webService1.HelloWorld();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webService1.AddAsync(3, 5);
            
            button3.Text = "Processing .....";
        }

        private void webService1_AddCompleted(object sender, localhost.AddCompletedEventArgs e)
        {
            button3.Text = e.Result.ToString();
        }
    }
}
