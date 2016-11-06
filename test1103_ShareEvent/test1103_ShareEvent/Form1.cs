using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1103_ShareEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           // this.textBox1.SelectionLength = 1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this.Text = textBox1.Text;
            this.textA.SelectionLength = 1;

        }

        int CountOfInsert = 0; // 看Insert鍵被按幾次
        private void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            // ↓↓↓  Insert鍵為奇數次, 此為複寫模式
            //TextBox txt = (TextBox)sender; //直接型別轉換 -- (1)
            if (CountOfInsert % 2 != 0)  //如果除以2不等於0 (為奇數)
            { 
            TextBox txt = sender as TextBox; // 型別轉換另一寫法 --(2)
            txt.SelectionLength = 1; //此為複寫模式
            }
        }

        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) //如果按鍵是Insert 鍵
                CountOfInsert++;  // 累計加一
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{tab}");
            }
            else if (e.KeyCode == Keys.F4)
            {
                SendKeys.Send("台中市");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // += : 一個事件發生有多個事件處理程式 += (加掛)上去
            textBox4.KeyPress += MyKeyPress; 
            textBox4.KeyDown += MyKeyDown;
        }
    }
}
