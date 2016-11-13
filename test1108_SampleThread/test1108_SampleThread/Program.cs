using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace test1108_SampleThread
{
    class Program
    {
        static void Main(string[] args)
        {
            // 新增專案 --> 主控台程式
            /*******************************
            System.Threading.Thread.Sleep(3000); // Sleep 為3秒鐘後才繼續執行下一行
            Console.WriteLine("Hello !");  //接受輸出
            Console.ReadLine();  // 接受輸入
            **********************************/

            Thread t = new Thread(DoWork);  // 委派完執行序,繼續執行下行
            t.Start();
            Console.WriteLine("OK"); // 因為 DoWork() 花的時間比較久,所以程式出來會先跑 OK 再來是 DoWork() is running...
        }
        static void DoWork()
        {
            Thread.Sleep(10);
            Console.WriteLine("DoWork() is running...");
        }

    }
}
