// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginServer.cs" company="">
//   
// </copyright>
// <summary>
//   The login server.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login
{
    using System.Net.Sockets;

    using Vanilla.Core;
    using Vanilla.Core.Network;

    /// <summary>
    /// The login server.
    /// </summary>
    public class LoginServer : Server
    {
        #region Public Methods and Operators

        /// <summary>
        /// The generate session.
        /// </summary>
        /// <param name="connectionID">
        /// The connection id.
        /// </param>
        /// <param name="connectionSocket">
        /// The connection socket.
        /// </param>
        /// <returns>
        /// The <see cref="Session"/>.
        /// </returns>
        public override Session GenerateSession(int connectionID, Socket connectionSocket)
        {
            return new LoginSession(connectionID, connectionSocket);
        }

        #endregion
    }
}