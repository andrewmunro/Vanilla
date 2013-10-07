using Vanilla.Core;
using Vanilla.Core.Network;

namespace Vanilla.Login
{
    public class LoginServer : Server
    {
        public override Session GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
        {
            return new LoginSession(connectionID, connectionSocket);
        }
    }
}
