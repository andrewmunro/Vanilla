using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Logout
{
    class PSLogoutCancelAcknowledgement : ServerPacket
    {
        public PSLogoutCancelAcknowledgement() : base((WorldOpcodes) WorldOpcodes.SMSG_LOGOUT_CANCEL_ACK)
        {
            Write((byte)0);
        }
    }
}
