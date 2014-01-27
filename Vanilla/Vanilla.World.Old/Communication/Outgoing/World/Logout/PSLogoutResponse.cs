namespace Vanilla.World.Communication.Outgoing.World.Logout
{
    using Vanilla.Core.Network.Packet;
    using System;
    using Vanilla.Core.Opcodes;

    internal class PSLogoutResponse : WorldPacket
    {
        public PSLogoutResponse() : base(WorldOpcodes.SMSG_LOGOUT_RESPONSE)
        {
            Write((UInt32)0);
            Write((byte)0);
        }
    }
}