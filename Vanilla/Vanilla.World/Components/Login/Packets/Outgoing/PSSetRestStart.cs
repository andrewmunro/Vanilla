namespace Vanilla.World.Components.Login.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal sealed class PSSetRestStart : WorldPacket
    {
        // TODO Implement
        public PSSetRestStart()
            : base(WorldOpcodes.SMSG_SET_REST_START)
        {
            this.Write((byte)0);
        }
    }
}