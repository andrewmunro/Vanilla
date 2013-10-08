// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSAccountDataTimes.cs" company="">
//   
// </copyright>
// <summary>
//   The ps account data times.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The ps account data times.
    /// </summary>
    internal class PSAccountDataTimes : ServerPacket
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAccountDataTimes"/> class.
        /// </summary>
        public PSAccountDataTimes()
            : base((WorldOpcodes)WorldOpcodes.SMSG_ACCOUNT_DATA_TIMES)
        {
            this.WriteNullByte(128);
        }

        #endregion
    }
}