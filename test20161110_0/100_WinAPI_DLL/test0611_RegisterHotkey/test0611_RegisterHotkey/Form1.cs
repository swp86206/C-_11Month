using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0611_RegisterHotkey {

    public partial class Form1 : Form {

        KeyboardHook hook = new KeyboardHook();

        public Form1() {
            InitializeComponent();
            hook.KeyPressed +=
            new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(test0611_RegisterHotkey.ModifierKeys.Control | test0611_RegisterHotkey.ModifierKeys.Alt, Keys.F12);
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e) {
            // show the keys pressed in a label.
            label1.Text = DateTime.Now.ToString();
        }

    }

    // End of Form1





}
