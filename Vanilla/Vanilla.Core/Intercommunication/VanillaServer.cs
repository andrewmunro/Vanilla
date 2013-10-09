using System.Net.Sockets;
using Vanilla.Core.Network;

namespace Vanilla.Core.Intercommunication
{
    public class VanillaServer : Server
    {
        public VanillaRouter Router { get; protected set; }

        public VanillaServer()
        {
            Router = new VanillaRouter();
        }

        public override Session GenerateSession(int connectionID, Socket connectionSocket)
        {
            return new VanillaSession(connectionID, connectionSocket);
        }
    }
}
