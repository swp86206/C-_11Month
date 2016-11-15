using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace test1111_TCPIP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It's Client Program.");
            TcpClient objC = new TcpClient();
            objC.Connect("127.0.0.1", 8000);  // 代表有連上 -- > "AcceptSocket, a session started." 

            NetworkStream st = objC.GetStream();
            StreamWriter w = new StreamWriter(st);
            w.AutoFlush = true; 
            StreamReader r = new StreamReader(st);

            string s;
            do
            {
                Console.Write("Please keyin your name: ");
                s = Console.ReadLine();
                w.WriteLine(s);
                string sFromServer = r.ReadLine();
                Console.WriteLine("server echo: " + sFromServer);
                
            } while (s != ".");
            

            //Console.ReadLine();


        }
    }
}
