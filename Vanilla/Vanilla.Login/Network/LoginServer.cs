using System.Net.Sockets;
using Vanilla.Core;
using Vanilla.Core.Network;

namespace Vanilla.Login.Network
{
    public class LoginServer : Server
    {
        public LoginRouter Router { get; private set; }

        public LoginServer()
        {
            Router = new LoginRouter();
        }

        public override Session GenerateSession(int connectionID, Socket connectionSocket)
        {
            return new LoginSession(this, connectionID, connectionSocket);
        }

        public void OnPacket(LoginSession session, byte[] data)
        {
            Router.CallHandler(session, data);
        }
    }
}