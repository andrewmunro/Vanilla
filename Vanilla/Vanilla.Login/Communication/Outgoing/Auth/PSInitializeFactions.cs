// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSInitializeFactions.cs" company="">
//   
// </copyright>
// <summary>
//   The ps initialize factions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The ps initialize factions.
    /// </summary>
    internal class PSInitializeFactions : ServerPacket
    {
        // TODO Pull factions from dbc and write using struct for each one
        /*        struct FactionState
        {
            uint32 ID;
            RepListID ReputationListID;
            uint32 Flags;
            int32 Standing;
            bool needSend;
            bool needSave;
        };*/
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSInitializeFactions"/> class.
        /// </summary>
        public PSInitializeFactions()
            : base((WorldOpcodes)WorldOpcodes.SMSG_INITIALIZE_FACTIONS)
        {
            this.WriteHexPacket(
                "40 00 00 00 02 00 00 00 00 00 00 00 00 00 02 00 00 00 00 02 00 00 00 00 10 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00 00 16 00 00 00 00 00 00 00 00 00 08 00 00 00 00 0E 00 00 00 00 09 00 00 00 00 00 00 00 00 00 11 00 00 00 00 11 00 00 00 00 11 00 00 00 00 11 00 00 00 00 06 00 00 00 00 06 00 00 00 00 06 00 00 00 00 06 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 06 00 00 00 00 00 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 14 00 00 00 00 02 00 00 00 00 10 00 00 00 00 00 00 00 00 00 10 00 00 00 00 10 00 00 00 00 06 00 00 00 00 10 00 00 00 00 0E 00 00 00 00 18 00 00 00 00 00 00 00 00 00 10 00 00 00 00 10 00 00 00 00 10 00 00 00 00 02 00 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ");
        }

        #endregion
    }
}