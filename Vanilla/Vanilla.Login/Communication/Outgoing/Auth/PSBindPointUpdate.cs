namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    internal sealed class PSBindPointUpdate : ServerPacket
    {
        #region Constructors and Destructors

        public PSBindPointUpdate()
            : base(WorldOpcodes.SMSG_BINDPOINTUPDATE)
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