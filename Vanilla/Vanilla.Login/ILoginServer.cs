using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Login
{
    [ServiceContract]
    public interface ILoginServer
    {
        [OperationContract]
        void RegisterRealm(string name);
    }
}
