using Vanilla.Core.Network.Session;

namespace Vanilla.Login.Network
{
    using System.Net.Sockets;

    using Vanilla.Core;
    using Vanilla.Core.Network;

    public class LoginServer : Server
    {
        public LoginServer()
        {
            Router = new LoginRouter();
        }

        public LoginRouter Router { get; private set; }

        public override AbstractSession GenerateSession(int connectionID, Socket connectionSocket)
        {
            return new LoginSession(this, connectionID, connectionSocket);
        }

        public void OnPacket(LoginSession session, byte[] data)
        {
            Router.CallHandler(session, data);
        }
    }
}