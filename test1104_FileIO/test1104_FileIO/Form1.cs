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

namespace test1104_FileIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Directory : 目錄,資料夾 
            //  ↓↓↓   Directory 是收納資料夾相關的功能, 直接取用,不用再New (靜態方法是放在類別那邊的，類別名稱直接呼叫的方法)
            Directory.CreateDirectory(@"c:\test123\test456\test789"); // 建一個資料夾 (屬於類別的方法)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 動態方法:根據類別造出物件出來,屬於這個物件的;程式產生出來就叫做動態
            // DirectoryInfo了解特定具體存在的資料夾資訊
            DirectoryInfo di = new DirectoryInfo(@"c:\temp");  //根據類別造物件實體出來
            di.CreateSubdirectory("test7898899");   // 屬於 di 物件的方法
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 檢驗一個檔案是否已經存在 

            /*****************冤枉路******************************
            bool bFound = true;
            FileInfo fi;
            try
            {
                fi = new FileInfo(@"c:\temp\test1233321233.txt"); // 可以new一個FileInfo物件,而FileInfo去處理一個不存在的檔案
            }
            catch
            {
                bFound = false;
            }
                if (fi.Exists) { button3.Text = "Yes"; }else { button3.Text = "No"; }
            **********************************************************/
            /*********************************************************
            if (File.Exists(@"c:\temp\test123123123123.txt")) //確認資料夾是否存在
            {
                if (MessageBox.Show("Over write file ? 蓋掉檔案嗎 ?", "Asking", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Copy(@"c:\temp\test123.txt", @"c:\temp\test.txt");
                }
            }
            *********************************************************/

            if (File.Exists(@"c:\temp\test123.txt")) //確認資料夾是否存在
            {
                DialogResult answer = MessageBox.Show("Over write file? 蓋掉檔案嗎?",
                     "Asking", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    File.Copy(@"c:\temp\test1.txt", @"c:\temp\test123.txt",true); // 來源：test1.txt　；　目標：test123.txt　；　true 代表會蓋掉檔案內容
                }
            }

            // File.Copy(@"c:\temp\test123.txt", @"c:\temp\test.txt");  // 將來源檔案及內容複製至目標資料夾並重新命名
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //  Copy 資料夾:要把每個檔案抓出來一個一個Copy
            listBox1.Items.Add(Application.ExecutablePath); // ExecutablePath：應用程式的檔名含路徑
            listBox1.Items.Add(Path.GetDirectoryName(Application.ExecutablePath)); //抓路徑
            listBox1.Items.Add(Path.GetFileName(Application.ExecutablePath)); //抓檔名
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //抓資料夾內的檔案清單
            //在此資料夾抓出所有txt的檔案
            string[] fileList = Directory.GetFiles(@"c:\temp", "*.txt",SearchOption.AllDirectories); //在路徑下,所有txt檔  SearchOption.AllDirectories 搜尋此目錄(資料夾)下所有資料
            foreach (string fileName in fileList)  // foreach  string 單向 in 集合項 ; foreach 陳述式是用來逐一查看集合，以取得所需的資訊
            {
                listBox1.Items.Add(fileName);  // 再把 string 單向,放入listBox1 秀出來
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Stream 串流 ,把檔案看成一段絲 (資料流), Stream是抽像物件,我們都使用Stream後代物件 xxxStream

            string content = "ABC中文字";
            //byte[] buffer = System.Text.Encoding.ASCII.GetBytes(content); // 將content(指定字串) 編碼成位元組陣列(傳回byte陣列) , 以ASCII排序   < ASCII 沒有中文字 >
            byte[] buffer = System.Text.Encoding.Unicode.GetBytes(content);


            FileStream st = new FileStream(@"c:\temp\test.txt", FileMode.Create);

            // st.WriteByte(67); // C

            // 位元組順序記號 UTF-16（小端序） 出現在位元組流的開頭則用來標識該位元組流的位元組序，是高位在前還是低位在前。
            st.WriteByte(255);
            st.WriteByte(254);
            st.Write(buffer, 0, buffer.Length); // 陣列 , offset , count

            st.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // UTF8 編碼

            string content = "ABCD中文字";  //UTF8 中文字佔3個byte
            //byte[] buffer = System.Text.Encoding.ASCII.GetBytes(content);
            //byte[] buffer = System.Text.Encoding.Unicode.GetBytes(content);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);

            FileStream st = new FileStream(@"c:\temp\test.txt", FileMode.Create);
            
            st.Write(buffer, 0, buffer.Length);

            st.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 大5碼 編碼

            string content = "ABCD中文字";  
            //byte[] buffer = System.Text.Encoding.ASCII.GetBytes(content);
            //byte[] buffer = System.Text.Encoding.Unicode.GetBytes(content);
            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
            Encoding coder = System.Text.Encoding.GetEncoding("Big5"); // 大五碼 中文佔2 byte ; Encoding是編碼器
            byte[] buffer = coder.GetBytes(content);  // 透過coder 編碼器將 content 編碼成大五碼



            FileStream st = new FileStream(@"c:\temp\test.txt", FileMode.Create);

            st.Write(buffer, 0, buffer.Length);

            st.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Q :如何把一段文字變成希望的編碼

            // .NET 內部是用UTF8 編碼

            string line = "洋基隊    NYY";
            //             0 1 2 3456789
            listBox1.Items.Add(line.Substring(7, 3)); // 位置7開始取3碼

                   line = "釀酒人隊  MIL";
            //             0 1 2 3 45678
            listBox1.Items.Add(line.Substring(6, 3)); // 位置6開始取3碼

                   line = "綠隊       GRN";
            //             0 1 2 345678
            listBox1.Items.Add(line.Substring(8, 3)); // 位置8開始取3碼

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string line = "零壹貳参肆伍";
            //             1234
            button10.Text = line.Substring(3, 1); // 參

          //  Q:  如何把UTF8 字串轉成 大5碼
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Encoding coder = System.Text.Encoding.GetEncoding("Big5");  //找Big5 編碼器
            StreamReader r = new StreamReader(@"c:\temp\teams.txt",coder);
            //StreamReader r = new StreamReader(@"c:\temp\teams.txt", true);

             
            while (!r.EndOfStream)// EndOfStream 取出到結尾的值
            {    
            string line = r.ReadLine();
            byte[] big5 = coder.GetBytes(line); // 把UTF8的內容轉成一堆byte
            byte[] teamCode = new byte[3]; // 3碼 [0,1,2]
            Array.Copy(big5, 10, teamCode, 0, 3);  // 來源陣列,10的位置,目地陣列,0的位置,長度取3碼  //取得球隊後面英文代號
            /*
                for (int i = 10; i <= 13; i++)
                {
                    teamCode[10 - i] = big5[i];
                }
                */

            line = coder.GetString(teamCode);
            
            listBox1.Items.Add(line);
            }
            r.Close();
            }

        private void button12_Click(object sender, EventArgs e)
        {
            // 字串轉成位元組陣列,再把位元組陣列StreamWriter

            // 用↓↓↓方法可以把資料寫進去

            string content = "ABCD中文字";
            StreamWriter w = new StreamWriter(@"c:\temp\test123.txt",false); //false代表不要 append ,蓋掉的意思
            w.WriteLine(content);
            w.WriteLine("Line2");
            w.WriteLine("Line3");
            w.WriteLine("Line4");
            w.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            StreamReader r = new StreamReader(@"c:\temp\test123.txt"); // 預設值是UTF8
            
            //開始讀檔案,但因為不知道檔案裡面有幾行
            while (!r.EndOfStream) // 在檔案結尾處之前
            {
                string sLine = r.ReadLine();  // ReadLine 是讀到換行符號後面的第一位,傳回不含換行符號的資料
                listBox1.Items.Add(sLine);               
            }
                        
            r.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"c:\temp\test123.txt",FileMode.Open); //FileMode.Open 開檔案
            long fileSize = fs.Length;  // fs的長度,資料型態是long
            byte[] buffer = new byte[fileSize]; //檔案多大,陣列大小就多大,剛好夠用 /*/準備一個夠大的陣列

            fs.Read(buffer, 0, (int)fileSize); //將資料讀進buffer裡,從0(頭)開始放,放fileSize的長度這麼多 /*/把東西讀進陣列裡

            string fileContent = System.Text.Encoding.UTF8.GetString(buffer); //把陣列變成字串,用UTF8編碼器  /*/把陣列解碼成字串

            fs.Close();

            textBox1.Text = fileContent;  //顯示執行結果

        }

        private void button15_Click(object sender, EventArgs e)
        {
           // 把圖片或網址抓下來,自行再研究
           // System.Net.WebClient wc = new System.Net.WebClient();
            //  wc.DownloadFile()
          
        }
    }
}
