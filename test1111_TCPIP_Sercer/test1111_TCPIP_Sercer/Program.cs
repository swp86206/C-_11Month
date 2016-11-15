using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace test1111_TCPIP_Sercer
{
    class Program
    {
        // VB 語言轉C#
        static void Main(string[] args)
        {
            Console.WriteLine("It's Server Program.");
            //objL = New TcpListener(New IPAddress({ 127, 0, 0, 1}), 8000)
            IPAddress objIpAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TcpListener objL = new TcpListener(objIpAddress, 8000); // 給他port 號
            objL.Start();


            Socket objSocket = objL.AcceptSocket();  // Socket 像Server 與Client 之間的虛擬檔案, 能讀寫Socket 就可以讀寫Server 與Client 之間的檔案
            // Socket是應用層與TCP/IP協議通信的中間軟體抽象層,它是一組介面。凡是網路兩端互相連線傳送資料時的溝通介面就是   // Socket其實就是一個門面模式,它把複雜的TCP/IP協議隱藏在Socket介面後面,對用戶來說,一組簡單的介面就是全部 // 


            Console.WriteLine("AcceptSocket, a session started.");

            NetworkStream st = new NetworkStream(objSocket);
            StreamWriter w = new StreamWriter(st);
            w.AutoFlush = true; // Server 傳回 Client
            StreamReader r = new StreamReader(st);

            string s;
            do {               
                s = r.ReadLine();
                Console.WriteLine("Server got: " + s);
                w.WriteLine("Echo " + s);
               } while (s != ".");
            st.Close(); // 關掉串流
            objSocket.Close(); // 關掉 Socket

            


            //Console.WriteLine("go ahead");
            //Console.ReadLine();
          //  Console.WriteLine("Listener is running...");
        }
    }
}
