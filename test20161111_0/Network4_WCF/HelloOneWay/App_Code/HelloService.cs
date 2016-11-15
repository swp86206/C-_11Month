using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloService" in code, svc and config file together.
public class HelloService : IHelloService
{
	public void DoWork()
	{
	}


    public string Hello(string sWho)
    {
        return "Hello! " + sWho;
    }

    public void HelloOneWay(string sWho)
    {
        Directory.CreateDirectory(@"c:\temp\demo");
        StreamWriter w = new StreamWriter(@"c:\temp\demo\OneWay.txt", true);
        w.WriteLine(string.Format("Time = {0}, Data = {1}", DateTime.Now, sWho));
        w.Close();
    }
}
