namespace Vanilla.World.Components.Logout.Packets.Outgoing
{
    using System;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal class PSLogoutResponse : WorldPacket
    {
        public PSLogoutResponse()
            : base(WorldOpcodes.SMSG_LOGOUT_RESPONSE)
        {
            this.Write((UInt32)0);
            this.Write((byte)0);
        }
    }
}