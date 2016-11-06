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

namespace test1104_MyNotepad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //因檔案一樣, 故宣告外面
        string currenFileName ="";

        private void 開啟OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 開啟舊檔後,需要知道內容是否變更過

            AskUserSaveFile(null);
            /**********************************************
            if (contentTextbox.Modified) // Modified 有變更過
            {
                DialogResult answer = MessageBox.Show("Save File ?", "Asking", MessageBoxButtons.YesNoCancel); //再次詢問是否儲存


                if (answer == DialogResult.Cancel)
                    return;
                if(answer == DialogResult.Yes)
                儲存SToolStripMenuItem_Click(null, null);
            }
            ***********************************************/
                
            
            openFileDialog1.Filter = "Text File|*.txt|All File|*,*";
            openFileDialog1.InitialDirectory = @"c:\temp"; //預設位置

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string fileName = openFileDialog1.FileName;
            currenFileName = fileName;
           
            StreamReader r = new StreamReader(fileName);
            contentTextbox.Text = r.ReadToEnd();  //整個檔案讀到結尾處
            r.Close();
            contentTextbox.Modified = false; //
        }

        private void 儲存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName;
            if (currenFileName == "") // 開啟舊檔後,要問一下
            {
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) //如果不是OK,就出去
                    return;
                fileName = saveFileDialog1.FileName;  //*/ fileName 是使用者得到的
                currenFileName = fileName;  // 第一次問完,已把檔案記在現行檔案
            }
            else
                fileName = currenFileName; //*/ fileName 是之前存下來的   // 之前知道的檔名   //知道現在在編輯哪一個檔案   


            StreamWriter w = new StreamWriter(fileName, false);
            w.Write(contentTextbox.Text);
            w.Close();
            contentTextbox.Modified = false; //儲存後且未修改,開啟舊檔則不會再次詢問是否儲存
        }

       
        private void 新增NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //內容清空

            AskUserSaveFile(null);  // 與下面註解相同,因重複,故獨立唯 一個方法

            /**********************************************
            if (contentTextbox.Modified) // Modified 有變更過
            {
                DialogResult answer = MessageBox.Show("Save File ?", "Asking", MessageBoxButtons.YesNoCancel); //再次詢問是否儲存


                if (answer == DialogResult.Cancel)
                    return;
                if (answer == DialogResult.Yes)
                    儲存SToolStripMenuItem_Click(null, null);
            }
            ***********************************************/
            
            contentTextbox.Text = "";
            currenFileName = "";

        }
       

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AskUserSaveFile(e);
        }

        private void AskUserSaveFile(FormClosingEventArgs e)
        {
            if (contentTextbox.Modified) // Modified 有變更過
            {
                DialogResult answer = MessageBox.Show("Save File ?", "Asking", MessageBoxButtons.YesNoCancel); //再次詢問是否儲存


                if (answer == DialogResult.Cancel)
                {
                    if (e == null)
                        return;
                    else
                    e.Cancel = true;
                }
                    
                if (answer == DialogResult.Yes)
                    儲存SToolStripMenuItem_Click(null, null);
            }
        }

        private void 編輯EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }

        private void 編輯EToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
