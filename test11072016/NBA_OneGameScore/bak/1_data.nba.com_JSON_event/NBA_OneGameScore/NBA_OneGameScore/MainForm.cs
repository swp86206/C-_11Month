using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NBA_OneGameScore {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            cboGameDate.Value = DateTime.Now.AddDays(-1);
        }


        // private CookieContainer _objCookieContainer = new CookieContainer();
        private string GrabHtmlPage(string sUrl) {
            string sPage = "";
            try {
                HttpWebRequest objHttpWebRequest = HttpWebRequest.Create(sUrl) as HttpWebRequest;
                // objHttpWebRequest.CookieContainer = _objCookieContainer;
                WebResponse objWebResponse = objHttpWebRequest.GetResponse();
                Stream objResponseStream = objWebResponse.GetResponseStream();
                StreamReader objReader = new StreamReader(objResponseStream);
                sPage = objReader.ReadToEnd();
            }
            catch {
                sPage = "Error";
            }
            return sPage;
        }

        private void cboGameDate_ValueChanged(object sender, EventArgs e) {
            workerDownloadGameList.RunWorkerAsync();
            // workerDownloadGameList_DoWork(null,null);
        }

        private void workerDownloadGameList_DoWork(object sender, DoWorkEventArgs e) {
            cboGameDate.Enabled = false;
            cboMatchup.Enabled = false;
            btnGo.Enabled = false;
            cboMatchup.Items.Clear();
            string sUrl = string.Format(
                "http://data.nba.com/json/cms/noseason/scoreboard/{0}/games.json",
                cboGameDate.Value.ToString("yyyyMMdd"));
            string sGamesJson = GrabHtmlPage(sUrl);

            JObject oJson = JObject.Parse(sGamesJson);

            var games = oJson.SelectToken("sports_content.games.game");
            foreach (var oGame in games) {
                string sItem = string.Format("{0}@{1} {2}",
                    oGame.SelectToken("visitor.team_key"),
                    oGame.SelectToken("home.team_key"),
                    oGame.Value<string>("id")
                    );
                cboMatchup.Items.Add(sItem);
            }
            cboMatchup.SelectedIndex = 0;
            cboGameDate.Enabled = true;
            cboMatchup.Enabled = true;
            btnGo.Enabled = true;
        }

        private void DownloadAndShowGame() {
            txtQ1.Text = ""; txtQ2.Text = ""; txtQ3.Text = ""; txtQ4.Text = "";
            lblMinMax.Text = "";
            chartScore.Series["expectedScore"].Points.Clear();
            chartScore.Series["avgScore"].Points.Clear();
            int iPeriod = 1;
            int iCurrentTotal = 0;
            int iLastExpected = 0;
            int[,] minMax = { { 999, 0 }, { 999, 0 }, { 999, 0 }, { 999, 0 }, { 999, 0 } };
            int iMinutesPerQuarter = 12;
            int iAvgLineTraceCount = 20;
            double nBookTotal = Convert.ToDouble(txtBookTotal.Text);
            double nPointsPerSecond = nBookTotal / (iMinutesPerQuarter * 60 * 4);
            chartScore.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            //chartScore.Series["expectedScore"].Points.AddXY("Q1", nBookTotal);
            //chartScore.Series["avgScore"].Points.AddXY("Q1", nBookTotal);
            chartScore.Series["expectedScore"].Points.AddY(nBookTotal);
            chartScore.Series["avgScore"].Points.AddY(nBookTotal);

            string sGameId = cboMatchup.Text.Substring(8);
            string sUrl = string.Format("http://data.nba.com/10s/json/cms/noseason/game/{0}/{1}/pbp_{2}.json",
                cboGameDate.Value.ToString("yyyyMMdd"),
                sGameId,
                "all"
                );
            string sJson = GrabHtmlPage(sUrl);
            if (sJson.Length <= 20) {
                this.Text = "Cannot get JSON data.";
                return;
            }
            JObject oJson = JObject.Parse(sJson);

            var plays = oJson.SelectToken("sports_content.game.play");
            foreach (var oPlay in plays) {
                iPeriod = oPlay.Value<int>("period");
                if (iPeriod > 4) {  // 暫不考慮 OT
                    this.Text += " OT!!";
                    break;
                }

                string sDescription = oPlay.Value<string>("description");
                lblEvent1.Text = lblEvent2.Text;
                lblEvent2.Text = sDescription;
                if (
                    sDescription.Contains("Missed") ||
                    sDescription.Contains("Made") ||
                    sDescription.Contains("Free Throw")
                    ) {

                    string sTimeAndScore = oPlay.Value<string>("clock");
                    int iMinute = Convert.ToInt32(sTimeAndScore.Substring(0, 2));
                    int iSecond = Convert.ToInt32(sTimeAndScore.Substring(3, 2));
                    int iRemain = iMinute * 60 + iSecond +
                        ((4 - iPeriod) * iMinutesPerQuarter * 60);
                    iCurrentTotal = oPlay.Value<int>("visitor_score") + oPlay.Value<int>("home_score");

                    int iExpectedScore = Convert.ToInt32(Math.Floor(iCurrentTotal + nPointsPerSecond * iRemain));
                    if (iExpectedScore != iLastExpected) {
                        if (iExpectedScore < minMax[0, 0])
                            minMax[0, 0] = iExpectedScore;
                        if (iExpectedScore > minMax[0, 1])
                            minMax[0, 1] = iExpectedScore;
                        if (iExpectedScore < minMax[iPeriod, 0])
                            minMax[iPeriod, 0] = iExpectedScore;
                        if (iExpectedScore > minMax[iPeriod, 1])
                            minMax[iPeriod, 1] = iExpectedScore;

                        iLastExpected = iExpectedScore;
                        // chartScore.Series["expectedScore"].Points.AddXY("Q" + iPeriod.ToString(), iExpectedScore);
                        chartScore.Series["expectedScore"].Points.AddY(iExpectedScore);

                        // Avg Line:
                        double nAvgTotal = 0;
                        double nTotal = 0;
                        int iCount = 0;
                        int iIndex = chartScore.Series["expectedScore"].Points.Count - 1;
                        while (iIndex >= 0 && iCount < iAvgLineTraceCount) {
                            iCount += 1;
                            nTotal += (int)chartScore.Series["expectedScore"].Points[iIndex].YValues[0];
                            iIndex -= 1;
                        }
                        if (iCount > 0) {
                            nAvgTotal = nTotal / iCount;
                            // chartScore.Series["avgScore"].Points.AddXY("Q" + iPeriod.ToString(), nAvgTotal);
                            chartScore.Series["avgScore"].Points.AddY(nAvgTotal);
                        }
                        else {
                            // chartScore.Series["avgScore"].Points.AddXY("Q" + iPeriod.ToString(), iExpectedScore);
                            chartScore.Series["avgScore"].Points.AddY(iExpectedScore);
                        }

                        switch (iPeriod) {
                            case 1:
                                txtQ1.Text = string.Format("{0}  Q{1}  {2:D2}:{3:D2}\r\n",
                                    iExpectedScore, iPeriod, iMinute, iSecond) + txtQ1.Text;
                                break;
                            case 2:
                                txtQ2.Text = string.Format("{0}  Q{1}  {2:D2}:{3:D2}\r\n",
                                    iExpectedScore, iPeriod, iMinute, iSecond) + txtQ2.Text;
                                break;
                            case 3:
                                txtQ3.Text = string.Format("{0}  Q{1}  {2:D2}:{3:D2}\r\n",
                                    iExpectedScore, iPeriod, iMinute, iSecond) + txtQ3.Text;
                                break;
                            case 4:
                                txtQ4.Text = string.Format("{0}  Q{1}  {2:D2}:{3:D2}\r\n",
                                    iExpectedScore, iPeriod, iMinute, iSecond) + txtQ4.Text;
                                break;

                        }
                    }

                }


            }

            lblMinMax.Text = string.Format("Min: {0}, Max: {1}", minMax[0, 0], minMax[0, 1]);
            for (int iQuarter = 1; iQuarter <= 4; iQuarter++) {
                if (minMax[iQuarter, 0] < 999)
                    lblMinMax.Text += string.Format("  Q{0}({1}~{2})",
                        iQuarter, minMax[iQuarter, 0], minMax[iQuarter, 1]);
            }

            lblMinMax.Text += "   Total: " + iCurrentTotal.ToString();
            chartScore.ChartAreas[0].AxisY.Minimum = minMax[0, 0] - 2;
            chartScore.ChartAreas[0].AxisY.Maximum = minMax[0, 1] + 2;
        }

        private void cboMatchup_SelectedIndexChanged(object sender, EventArgs e) {
            this.Text = cboMatchup.Text.Substring(0, 7);
        }

        private void btnGo_Click(object sender, EventArgs e) {
            DownloadAndShowGame();
        }

        private void timerRefresh_Tick(object sender, EventArgs e) {
            DownloadAndShowGame();
        }

        private void txtRefreshSeconds_TextChanged(object sender, EventArgs e) {
            int iSecond = 0;
            try {
                iSecond = Convert.ToInt32(txtRefreshSeconds.Text);
            }
            catch {

            }
            timerRefresh.Interval = (iSecond > 0) ? iSecond * 1000 : 300000;
            timerRefresh.Enabled = (iSecond > 6) ? true : false;
        }

        private void notifyIconMain_DoubleClick(object sender, EventArgs e) {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Visible = false;
            }
        }


    }
}
