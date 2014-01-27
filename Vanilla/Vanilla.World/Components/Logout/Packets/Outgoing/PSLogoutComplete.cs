namespace Vanilla.World.Components.Logout.Packets.Outgoing
{

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal class PSLogoutComplete : WorldPacket
    {
        public PSLogoutComplete()
            : base(WorldOpcodes.SMSG_LOGOUT_COMPLETE)
        {
            this.Write((byte)0);
        }
    }
}