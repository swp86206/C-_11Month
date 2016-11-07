using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace test1107_Generic {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = 100;
            int y = 200;

            IntSwap(ref x, ref y);

            button1.Text = string.Format("x = {0}, y = {1}", x, y);
        }

        private static void IntSwap(ref int x, ref int y) {
            int temp = x;
            x = y;
            y = temp;
        }

        private void button2_Click(object sender, EventArgs e) {
            double x = 100.1;
            double y = 200.2;

            DoubleSwap(ref x, ref y);
            button2.Text = string.Format("x = {0}, y = {1}", x, y);
        }

        private static void DoubleSwap(ref double x, ref double y) {
            double temp = x;
            x = y;
            y = temp;
        }

        private void button3_Click(object sender, EventArgs e) {
            string x = "ABC";
            string y = "XYZ";
            StringSwap(ref x, ref y);
            button3.Text = string.Format("x = {0}, y = {1}", x, y);
        }

        private static void StringSwap(ref string x, ref string y) {
            string temp = x;
            x = y;
            y = temp;
        }

        private void button4_Click(object sender, EventArgs e) {
            int x = 100;
            int y = 200;
            Swap<int>(ref x, ref y);
            button4.Text = string.Format("x = {0}, y = {1}", x, y);
        }

        private static void Swap<T>(ref T x, ref T y) {
            T temp = x;
            x = y;
            y = temp;
        }

        // Generic 
        private void button5_Click(object sender, EventArgs e) {
            double x = 100.1;
            double y = 200.2;

            Swap<double>(ref x, ref y);
            button5.Text = string.Format("x = {0}, y = {1}", x, y);
        }

        private void button6_Click(object sender, EventArgs e) {
            ArrayList col = new ArrayList();
            col.Add(100);
            col.Add("Jeremy");

            // button6.Text = string.Format("{0}, {1}", col[0], col[1]);
            button6.Text = ((int)col[0]).ToString();
        }

        private void button7_Click(object sender, EventArgs e) {
            List<string> stringList = new List<string>();
            stringList.Add("Chien");
            button7.Text = stringList[0];

            List<int> intList = new List<int>();
            intList.Add(100);
            this.Text = intList[0].ToString();

        }
    }

    

}
