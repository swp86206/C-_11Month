using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;

namespace test0303_DownAndParseHtmlFile {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            HtmlAgilityPack.HtmlWeb objHtmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = objHtmlWeb.Load("http://www.appledaily.com.tw/");

            HtmlNode html = doc.DocumentNode;
            // #realtimenews > aside > ul > li:nth-child(4) > a
            // HtmlNode node = html.SelectSingleNode("//*[@id=\"realtimenews\"]/aside/ul/li");
            HtmlNodeCollection nodes = html.SelectNodes("//*[@id=\"realtimenews\"]/aside/ul/li/a");
            foreach (HtmlNode node in nodes) {
                listBox1.Items.Add(node.InnerText);
            }

            button1.Text = "OK";
        }
    }
}
