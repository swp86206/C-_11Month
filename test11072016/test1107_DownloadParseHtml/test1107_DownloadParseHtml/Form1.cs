using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace test1107_DownloadParseHtml {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            HtmlWeb objWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = objWeb.Load("http://www.appledaily.com.tw/");

            HtmlNode root = doc.DocumentNode;
            // //*[@id="realtimenews"]/aside/ul/li[1]
            // //*[@id="realtimenews"]/aside/ul/li[1]/time
            HtmlNode timeNode = root.SelectSingleNode(
                "//*[@id='realtimenews']/aside/ul/li[1]/time");
            if (timeNode == null) {
                button1.Text = "Not found";
                return;
            }
            button1.Text = timeNode.InnerText;

            var nodeList = root.SelectNodes("//*[@id='realtimenews']/aside/ul/li");
            foreach (var node in nodeList) {
                string s = node.SelectSingleNode("./a").InnerText;
                listBox1.Items.Add(s);
            }


        }
    }
}
