using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.Network;

namespace Vanilla.Core.Components
{
    public class GenericServerComponent<TCore, TServer, TRouter> where TCore : VanillaCore where TServer : Server
    {
        public TCore Core;
        public TServer Server;
        public TRouter Router;

        public GenericServerComponent(TCore core)
        {
            Core = core;
        }
    }
}
