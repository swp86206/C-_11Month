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
using Newtonsoft.Json.Linq;



namespace test1107_ReadNBA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 透過WebClient 把網址下載下來存成檔案
            System.Net.WebClient objWebClient = new System.Net.WebClient();  // 透過WebClient把網頁內容下在下來變成檔案  --- (1)
            objWebClient.DownloadFile(
                "http://data.nba.com/json/cms/noseason/scoreboard/20161105/games.json",
                @"c:\temp\nba.txt");

            button1.Text = "OK";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 透過StreamReader 把檔案讀出來......     // 再把檔案讀進來變成 jasonString字串 ---  (2)
            System.IO.StreamReader r =
                new System.IO.StreamReader(@"c:\temp\nba.txt");
            string jasonString = r.ReadToEnd();
            r.Close();

            //textBox1.Text = jasonString;

            //NuGet 第一個
            // using Newtonsoft.Json.Linq;

            // 直接找到底層去抓資料
            JObject obj = JObject.Parse(jasonString); //透過Object 解讀字串   // 將 jasonString字串 解讀成 JObject 的 JSON 物件  ---  (3)
            JToken objToken = obj.SelectToken("sports_content.sports_meta.season_meta.calendar_date");// 依節點去找出值 , Token：節點   //依這個路徑找出他的值  // 透過JSON物件的 SelectToken 方法,得到 JToken 物件 ---  (4)

            /*
            sports_content
             .sports_meta
              .season_meta
               .calendar_date
               */

            textBox1.Text += objToken.ToString()
                + System.Environment.NewLine + System.Environment.NewLine;  //NewLine 換行

            // 找到上一層,再抓其屬性,進而找出其值
            objToken = obj.SelectToken("sports_content.sports_meta.season_meta");

            string s = objToken.Value<string>("calendar_date"); // 上一層,透過物件去抓下面的屬性　　// 泛型
            textBox1.Text += s
                + System.Environment.NewLine + System.Environment.NewLine;

            int iYear = objToken.Value<int>("season_year"); // 上一層,透過物件去抓下面的屬性　　// 泛型
            textBox1.Text += iYear.ToString()
                + System.Environment.NewLine + System.Environment.NewLine;


            var gameList = obj.SelectToken("sports_content.games.game");
           
            foreach (var game in gameList)
            {


                string sMatehup = string.Format("{0}@{1}",
                    game.SelectToken("visitor").Value<string>("team_key")
                   ,game.SelectToken("home").Value<string>("team_key")
                    );                    

                textBox1.Text += sMatehup
                    + System.Environment.NewLine + System.Environment.NewLine;


            }


            button2.Text = "OK";
        }
    }
}
