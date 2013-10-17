namespace Vanilla.Login.Network
{
    using System.Net.Sockets;
    using Vanilla.Core.Network;
    using Vanilla.Core.Network.Session;

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
    }
}