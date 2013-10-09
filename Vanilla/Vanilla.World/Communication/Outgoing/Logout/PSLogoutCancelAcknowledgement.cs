namespace Vanilla.World.Communication.Outgoing.Logout
{
    #region

    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSLogoutCancelAcknowledgement : ServerPacket
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