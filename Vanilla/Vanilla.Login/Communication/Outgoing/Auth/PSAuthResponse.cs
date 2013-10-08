// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSAuthResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The ps auth response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The ps auth response.
    /// </summary>
    internal class PSAuthResponse : ServerPacket
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAuthResponse"/> class.
        /// </summary>
        public PSAuthResponse()
            : base((WorldOpcodes)WorldOpcodes.SMSG_AUTH_RESPONSE)
        {
            Write((byte)ResponseCodes.AUTH_OK);
        }

        #endregion
    }
}