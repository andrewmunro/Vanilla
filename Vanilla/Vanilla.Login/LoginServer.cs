namespace Vanilla.Login
{
    using System.Net.Sockets;
    using Vanilla.Core;
    using Vanilla.Core.Network;

    public class LoginServer : Server
    {
        #region Public Methods and Operators

        public override Session GenerateSession(int connectionID, Socket connectionSocket)
        {
            return new LoginSession(connectionID, connectionSocket);
        }

        #endregion
    }
}