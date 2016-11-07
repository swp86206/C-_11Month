using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace test0303_ReadXML {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\temp\test.xml");

            XmlNode objRss = doc.SelectSingleNode("/rss");
            XmlAttribute att = objRss.Attributes["version"];
            listBox1.Items.Add(att.Value);

            XmlNode obj = doc.SelectSingleNode("/rss/channel/title");
            if (obj == null)
                return;

            listBox1.Items.Add(obj.InnerText);

            XmlNodeList items = doc.SelectNodes("/rss/channel/item");
            foreach (XmlNode item in items) {
                string s = item.SelectSingleNode("./title").InnerText;
                listBox1.Items.Add(s);
            }

            button1.Text = "OK";

        }

        private void button2_Click(object sender, EventArgs e) {
            /*
            // ....  <ul class="mrt ...</ul>  ....
            // 01234567890123456789012345678901234567890123456789
            //           1         2         
            int iStart = sPage.indexOf("<ul class=\"mrt");  // 6
            int iEnd = sPage.indexOf("</ul>");              // 24  24 - 6 = 18
            string sNewList = sPage.SubString(iStart, iEnd - iStart + 5);  // 23
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sNewList);
            */
        }
    }
}
