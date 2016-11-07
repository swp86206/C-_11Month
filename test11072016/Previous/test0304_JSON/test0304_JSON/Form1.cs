using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace test0304_JSON {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            //TLocation obj = new TLocation();
            //obj.X = 100;
            //obj.Y = 200;
            //obj.Name = "TC";
            TLocation obj = new TLocation() { X = 100, Y = 200, Name = "TC" };
            string sJson = JsonConvert.SerializeObject(obj);
            textBox1.Text += sJson + "\r\n\r\n";

        }

        private void button2_Click(object sender, EventArgs e) {
            // string sJson = "{\"X\":100,\"Y\":200,\"Name\":\"TC\"}";
            string sJson = textBox2.Text;
            TLocation obj =  JsonConvert.DeserializeObject<TLocation>(sJson);
            textBox1.Text += obj.Name + "\r\n\r\n";

            /*

            var obj = JSON.parse("...");
            obj.skills[2].level


            */
        }
    }

    public class TLocation {
        public int X { set; get;  }
        public int Y { set; get; }
        public string Name { set; get; }
    }


}
