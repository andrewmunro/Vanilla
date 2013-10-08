// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSSetRestStart.cs" company="">
//   
// </copyright>
// <summary>
//   The ps set rest start.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The ps set rest start.
    /// </summary>
    internal class PSSetRestStart : ServerPacket
    {
        // TODO Implement
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSetRestStart"/> class.
        /// </summary>
        public PSSetRestStart()
            : base((WorldOpcodes)WorldOpcodes.SMSG_SET_REST_START)
        {
            Write((byte)0);
        }

        #endregion
    }
}