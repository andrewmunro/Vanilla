namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public sealed class PSTransferPending : WorldPacket
    {
        public PSTransferPending(int mapID)
            : base(WorldOpcodes.SMSG_TRANSFER_PENDING)
        {
            this.Write(mapID);
        }
    }
}