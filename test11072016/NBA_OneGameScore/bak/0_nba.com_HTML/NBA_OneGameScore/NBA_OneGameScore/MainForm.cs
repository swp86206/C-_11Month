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

namespace NBA_OneGameScore {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        // private CookieContainer _objCookieContainer = new CookieContainer();
        private string GrabHtmlPage(string sUrl) {
            HttpWebRequest objHttpWebRequest = HttpWebRequest.Create(sUrl) as HttpWebRequest;
            // objHttpWebRequest.SendChunked = false;
            // objHttpWebRequest.CookieContainer = _objCookieContainer;
            //...
            WebResponse objWebResponse = objHttpWebRequest.GetResponse();
            Stream objResponseStream = objWebResponse.GetResponseStream();
            StreamReader objReader = new StreamReader(objResponseStream);
            string sPage = objReader.ReadToEnd();
            return sPage;
        }

        private void btnGo_Click(object sender, EventArgs e) {
            DownloadAndShowGame();
        }

        private void DownloadAndShowGame() {
            this.Text = txtUrl.Text.Substring(34, 3) + "@" + txtUrl.Text.Substring(37, 3);
            txtQ1.Text = ""; txtQ2.Text = ""; txtQ3.Text = ""; txtQ4.Text = "";
            lblMinMax.Text = "";
            chartScore.Series["score"].Points.Clear();

            int iMinutesPerQuarter = 12; //  Convert.ToInt32(txtMinutesPerQuarter.Text);
            double nBookTotal = Convert.ToDouble(txtBookTotal.Text);
            double nPointsPerSecond = nBookTotal / (iMinutesPerQuarter * 60 * 4);
            chartScore.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;



            string sPage = GrabHtmlPage(txtUrl.Text);
            HtmlAgilityPack.HtmlDocument objHtmlDocument = new HtmlAgilityPack.HtmlDocument();
            objHtmlDocument.LoadHtml(sPage);


            int iCurrentQuarter = 1;
            int iCurrentTotal = 0;
            int iLastExpected = 0;

            int[,] minMax = { { 999, 0 }, { 999, 0 }, { 999, 0 }, { 999, 0 }, { 999, 0 } };
            HtmlNodeCollection objTrList = objHtmlDocument.DocumentNode.SelectNodes("//*[@id='nbaGIPBP']/table/tr");
            if (objTrList == null) {
                this.Text = "Error: Cannot found out Play-by-Play records.";
                return;
            }
            foreach (HtmlNode objTr in objTrList) {
                // 某一節是否結束
                if (objTr.SelectSingleNode("td[1]") != null) {
                    string sTestEndOfQuarter = objTr.SelectSingleNode("td[1]").InnerText;
                    if (sTestEndOfQuarter.IndexOf("End") >= 0 && sTestEndOfQuarter.IndexOf("Quarter") >= 0) {
                        iCurrentQuarter += 1;
                        if (iCurrentQuarter > 4)
                            break;
                    }
                }
                if (objTr.SelectSingleNode("td[3]") == null) {
                    continue;
                }

                string sLogText = objTr.SelectSingleNode("td[1]").InnerText +
                    objTr.SelectSingleNode("td[3]").InnerText;
                if (
                    sLogText.Contains("Missed") ||
                    sLogText.Contains("Made") ||
                    sLogText.Contains("Free Throw")
                    ) {

                    string sTimeAndScore = objTr.SelectSingleNode("td[2]").InnerText;
                    if (sTimeAndScore.IndexOf("[") > 0) {
                        string[] sScore = sTimeAndScore.Substring(sTimeAndScore.IndexOf("[") + 5,
                            sTimeAndScore.IndexOf("]") - sTimeAndScore.IndexOf("[") - 5).Split('-');
                        iCurrentTotal = Convert.ToInt32(sScore[0]) + Convert.ToInt32(sScore[1]);
                    }

                    int iMinute = Convert.ToInt32(sTimeAndScore.Substring(0, 2));
                    int iSecond = Convert.ToInt32(sTimeAndScore.Substring(3, 2));
                    int iRemain = iMinute * 60 + iSecond +
                        ((4 - iCurrentQuarter) * iMinutesPerQuarter * 60);

                    int iExpectedScore = Convert.ToInt32(Math.Floor(iCurrentTotal + nPointsPerSecond * iRemain));
                    if (iExpectedScore != iLastExpected) {
                        if (iExpectedScore < minMax[0, 0])
                            minMax[0, 0] = iExpectedScore;
                        if (iExpectedScore > minMax[0, 1])
                            minMax[0, 1] = iExpectedScore;
                        if (iExpectedScore < minMax[iCurrentQuarter, 0])
                            minMax[iCurrentQuarter, 0] = iExpectedScore;
                        if (iExpectedScore > minMax[iCurrentQuarter, 1])
                            minMax[iCurrentQuarter, 1] = iExpectedScore;

                        iLastExpected = iExpectedScore;
                        chartScore.Series["score"].Points.AddXY("Q" + iCurrentQuarter.ToString(), iExpectedScore);
                        switch (iCurrentQuarter) {
                            case 1:
                                txtQ1.Text += string.Format("{0}  Q{1}  {2:D2}:{3:D2}\r\n",
                                    iExpectedScore, iCurrentQuarter, iMinute, iSecond);
                                break;
                            case 2:
                                txtQ2.Text += string.Format("{0}  Q{1}  {2:D2}:{3:D2}\r\n",
                                    iExpectedScore, iCurrentQuarter, iMinute, iSecond);
                                break;
                            case 3:
                                txtQ3.Text += string.Format("{0}  Q{1}  {2:D2}:{3:D2}\r\n",
                                    iExpectedScore, iCurrentQuarter, iMinute, iSecond);
                                break;
                            case 4:
                                txtQ4.Text += string.Format("{0}  Q{1}  {2:D2}:{3:D2}\r\n",
                                    iExpectedScore, iCurrentQuarter, iMinute, iSecond);
                                break;

                        }
                    }

                }

            }  // end of foreach

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


    }
}
