using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Core.Intercommunication
{
    public class VanillaSession : Session
    {
        public VanillaServer Server;

        public VanillaSession(int connectionID, Socket socket) : base(connectionID, socket) { }

        protected override void OnPacket(byte[] data)
        {
            Server.Router.CallHandler(this, data);
        }
    }
}
