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

namespace test1107_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // http://udn.com/rssfeed/news/1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 從網址把資料扛回來
            System.Net.WebClient objWebClient = new System.Net.WebClient();
            objWebClient.DownloadFile("http://udn.com/rssfeed/news/1", @"c:\temp\udn.xml");
            button1.Text = "OK";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\temp\udn.xml");  //檔名含路徑
            XmlNode node = doc.SelectSingleNode("/rss/channel/title"); // 把節點找出來
            
            if (node == null)
            {
                button2.Text = "not found";
                return;
            }

            listBox1.Items.Add(node.InnerText);


            XmlNodeList nodeList = doc.SelectNodes("/rss/channel/item"); //一組節點清單
            foreach (XmlNode objNode in nodeList)
            {
                string s = objNode.SelectSingleNode("./title").InnerText;
                listBox1.Items.Add(s);
            }

            button2.Text =nodeList.Count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Net.WebClient objWebClient = new System.Net.WebClient();
            objWebClient.DownloadFile("http://gd2.mlb.com/components/game/mlb/year_2015", @"c:\temp\udn1.xml");
            button3.Text = "OK";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 找屬性
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\temp\udn.xml");  //檔名含路徑
            XmlNode node = doc.SelectSingleNode("/rss");
            button4.Text = node.Attributes["version"].Value; // 讀屬性
        }
    }
}
