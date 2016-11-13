using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test1109_nightAbort
{
    class Program
    {
        // join 為等事情做完會合,再下一行
        static void Main(string[] args)
        {
            Thread t1 = new Thread(DoWork);
            t1.Start("A");  // 呼叫 DoWork 要傳資料進去

            Console.WriteLine("-- start --");
            Thread.Sleep(50);
            t1.Abort();
        }
        static void DoWork(Object data)  // 靜態程式
        {
            try
            {
                Random dice = new Random();
                string s = data.ToString(); // 傳進來的資料為 string s
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(dice.Next(10, 100)); // 暫停n毫秒 (10~99) 
                    Console.WriteLine(s);
                }
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("Canceled.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) // 除了中止的例外狀況,再秀出其他問題
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
