// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSBindPointUpdate.cs" company="">
//   
// </copyright>
// <summary>
//   The ps bind point update.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The ps bind point update.
    /// </summary>
    internal class PSBindPointUpdate : ServerPacket
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSBindPointUpdate"/> class.
        /// </summary>
        public PSBindPointUpdate()
            : base((WorldOpcodes)WorldOpcodes.SMSG_BINDPOINTUPDATE)
        {
            // TODO Pull hearthstone info from DB.
            Write((float)1); // X
            Write((float)1); // Y
            Write((float)1); // Z
            Write((uint)1); // MAPID
            Write((short)1); // AREAID
        }

        #endregion
    }
}