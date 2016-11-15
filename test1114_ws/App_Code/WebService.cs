using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// WebService 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //如果使用設計的元件，請取消註解下列一行
        //InitializeComponent(); 
    }

    [WebMethod(Description ="天線寶寶說你好 Hello")]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(Description ="加入兩個數字")]
    public int Add(int x, int y)
    {
        System.Threading.Thread.Sleep(3000);
        return x + y;
    }

    [WebMethod(EnableSession =true)]
    public string SetData (string key, string value)
    {
        Session[key] = value;
        return value;
    }

    [WebMethod(EnableSession = true)]
    public string GetData(string key)
    {
        string result = "Not Found ! 沒有";

        if (Session[key] != null)
            result = Session[key].ToString();
        return result;
       
    }

}
