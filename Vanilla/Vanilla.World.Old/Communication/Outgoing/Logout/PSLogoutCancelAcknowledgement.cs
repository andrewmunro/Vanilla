using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.Logout
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSLogoutCancelAcknowledgement : WorldPacket
    {
        #region Constructors and Destructors

        public PSLogoutCancelAcknowledgement()
            : base((WorldOpcodes)WorldOpcodes.SMSG_LOGOUT_CANCEL_ACK)
        {
            Write((byte)0);
        }

        #endregion
    }
}