using System;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Logout
{
    class SCLogoutResponse : ServerPacket
    {
        public SCLogoutResponse(): base(WorldOpcodes.SMSG_LOGOUT_RESPONSE)
        {
            Write((UInt32) 0);
            Write((byte) 0);
        }
    }
}
