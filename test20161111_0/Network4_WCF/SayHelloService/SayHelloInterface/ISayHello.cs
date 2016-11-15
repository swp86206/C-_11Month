using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace SayHelloInterface
{
    [ServiceContract]
    public interface ISayHello
    {
        [OperationContract]
        string SayHello(string sUserName);
    }
}
