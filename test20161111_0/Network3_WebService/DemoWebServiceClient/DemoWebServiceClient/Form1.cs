using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWebServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ws.AddAsync(3, 5);
            button1.Text = "Processing...";
        }

        
        private void ws_AddCompleted(object sender, localhost.AddCompletedEventArgs e)
        {
            button1.Text = e.Result.ToString();
        }

    }
}
