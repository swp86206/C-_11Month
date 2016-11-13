using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace test1108_Conffict
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 啟動但不偵錯
        //read lock: [share lock] 任何人可讀,但不可改資料
        // write lock : [專屬鎖定] 只有我可以 ,別人連看資料都不行 

        int iCount = 100;
        ReaderWriterLock locker = new ReaderWriterLock();  // Reader[共用] Writer[專屬] Lock[鎖定]

        void ReadData()
        {
            //Monitor.Enter(this); //Monitor 像是警衛 -- 鎖
            locker.AcquireReaderLock(10000);
            listBox1.Items.Add("ReadData: " + iCount.ToString());
            //locker.ReleaseReaderLock();

            Thread.Sleep(5000);

            //locker.AcquireReaderLock(10000);
            listBox1.Items.Add("ReadData: " + iCount.ToString());
            locker.ReleaseReaderLock();
            //Monitor.Exit(this); //Monitor 像是警衛 -- 解開
        }

        void WriteData()
        {
            //Monitor.Enter(this);
            locker.AcquireWriterLock(10000);
            iCount += 100;
            listBox1.Items.Add("WriteData: " + iCount.ToString());

            Thread.Sleep(5000);

            iCount += 100;
            listBox1.Items.Add("WriteData: " + iCount.ToString());
            locker.ReleaseWriterLock();
            //Monitor.Exit(this);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(ReadData);
            t.Start();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(WriteData);
            t.Start();
        }
    }
}
