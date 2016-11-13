using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace test1108_join
{
    class Program
    {
        // join 為等事情做完會合,再下一行
        static void Main(string[] args)
        {
            Thread t1 = new Thread(DoWork);
            Thread t2 = new Thread(DoWork);
            t1.Start("A");  // 呼叫 DoWork 要傳資料進去
            t2.Start("B");

            Console.WriteLine("-- start --");

            // Not a good idea:
            //while (t1.ThreadState != ThreadState.Stopped) {
            //    ;
            //}
            //while (t2.ThreadState != ThreadState.Stopped) {
            //    ;
            //}


            // 分頭進行，會合回來
            t1.Join();  // 程式執行到此行等 t1 執行完,再繼續往下
            t2.Join();

            Console.WriteLine("-- Done --");
        }
        static void DoWork(Object data)  // 靜態程式
        {
            Random dice = new Random(); 
            string s = data.ToString(); // 傳進來的資料為 string s
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(dice.Next(10, 100)); // 暫停n毫秒 (10~99) 
                Console.WriteLine(s);
            }
        }
    }
}
