namespace Vanilla.World.Components.Logout.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal class PSLogoutCancelAcknowledgement : WorldPacket
    {
        public PSLogoutCancelAcknowledgement()
            : base(WorldOpcodes.SMSG_LOGOUT_CANCEL_ACK)
        {
            this.Write((byte)0);
        }
    }
}