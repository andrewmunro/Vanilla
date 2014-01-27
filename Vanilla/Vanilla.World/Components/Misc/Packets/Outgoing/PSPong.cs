namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public class PSPong : WorldPacket
    {
        public PSPong(uint ping)
            : base(WorldOpcodes.SMSG_PONG)
        {
            this.Write((ulong)ping);
        }
    }
}