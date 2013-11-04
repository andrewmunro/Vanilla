namespace Vanilla.World.Components.Login.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal sealed class PSBindPointUpdate : WorldPacket
    {
        public PSBindPointUpdate()
            : base(WorldOpcodes.SMSG_BINDPOINTUPDATE)
        {
            // TODO Pull information from spell location and set hearthstone
            this.Write((float)1); // X
            this.Write((float)1); // Y
            this.Write((float)1); // Z
            this.Write((uint)1); // MAPID
            this.Write((short)1); // AREAID
        }
    }
}