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
using System.Net;
using System.IO;

namespace test0304_ReadNBAGames {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            WebClient objWebClient = new WebClient();
            objWebClient.DownloadFile("http://data.nba.com/json/cms/noseason/scoreboard/20160302/games.json",
                @"c:\temp\nba.txt");
            button1.Text = "OK";
        }

        private void button2_Click(object sender, EventArgs e) {
            StreamReader r = new StreamReader(@"c:\temp\nba.txt");
            string sJson = r.ReadToEnd();
            r.Close();

            JObject objJson = JObject.Parse(sJson);

            var objToken = objJson.SelectToken("sports_content.sports_meta.season_meta.calendar_date");
            string test = objToken.ToString();
            textBox1.Text += test + "\r\n\r\n";

            objToken = objJson.SelectToken("sports_content.sports_meta.season_meta");
            test = objToken.Value<string>("calendar_date");
            textBox1.Text += test + "\r\n\r\n";

            objToken = objJson.SelectToken("sports_content.sports_meta.season_meta");
            int iTest = objToken.Value<int>("season_year");
            textBox1.Text += iTest.ToString() + "\r\n\r\n";

            var gameList = objJson.SelectToken("sports_content.games.game");
            foreach (JToken game in gameList) {
                // away@home (nnn:nnn)
                JToken awayTeam = game.SelectToken("visitor");
                string awayTeamName = awayTeam.Value<string>("team_key");
                int awayScore = awayTeam.Value<int>("score");
                JToken homeTeam = game.SelectToken("home");
                string homeTeamName = homeTeam.Value<string>("team_key");
                int homeScore = homeTeam.Value<int>("score");
                string sLine = string.Format("{0}@{1} ({2}:{3})",
                    awayTeamName, homeTeamName,
                    awayScore, homeScore
                    );


                textBox1.Text += sLine + "\r\n\r\n";
            }




        }
    }
}
