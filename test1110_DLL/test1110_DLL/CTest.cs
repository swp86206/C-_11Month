using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1110_DLL
{
    public class CTest
    {
        public string Hello (string name)
        {
            return "Hello" + name;
        }
        public static string GetTime ()
        {
            return DateTime.Now.ToString();
        }
    }
}
