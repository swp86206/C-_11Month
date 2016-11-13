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

namespace test1107_DownloadParseHtml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 沒有RSS下, 直接扛資料
            HtmlWeb objWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = objWeb.Load("http://www.appledaily.com.tw/");
            HtmlNode root = doc.DocumentNode; //在根結點去找SelectSingleNode

            // 檢查 --> 右鍵 Copy Xpath
            //*[@id="realtimenews"]/aside/ul/li[2]/a
            //*[@id="realtimenews"]/aside/ul/li[2]/time

            HtmlNode timeNode = root.SelectSingleNode("//*[@id='realtimenews']/aside/ul/li[2]/time");

            if (timeNode == null)
            {
                button1.Text = "Not found";
                return;
            }
            button1.Text = timeNode.InnerText;

            // 得到一組清單
            var nodeList = root.SelectNodes("//*[@id='realtimenews']/aside/ul/li");
            foreach(var node in nodeList)
            {
                string s = node.SelectSingleNode("./a").InnerText;
                listBox1.Items.Add(s);
            }

        }
    }
}
