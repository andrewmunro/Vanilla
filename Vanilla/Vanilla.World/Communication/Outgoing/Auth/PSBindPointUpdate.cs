namespace Vanilla.World.Communication.Outgoing.Auth
{
    #region

    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal sealed class PSBindPointUpdate : ServerPacket
    {
        #region Constructors and Destructors

        public PSBindPointUpdate()
            : base(WorldOpcodes.SMSG_BINDPOINTUPDATE)
        {
            // TODO Pull information from spell location and set hearthstone
            Write((float)1); // X
            Write((float)1); // Y
            Write((float)1); // Z
            Write((uint)1); // MAPID
            Write((short)1); // AREAID
        }

        #endregion
    }
}