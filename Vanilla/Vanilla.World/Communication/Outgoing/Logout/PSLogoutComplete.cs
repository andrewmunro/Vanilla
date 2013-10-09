namespace Vanilla.World.Communication.Outgoing.Logout
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSLogoutComplete : ServerPacket
    {
        #region Constructors and Destructors

        public PSLogoutComplete()
            : base((WorldOpcodes)WorldOpcodes.SMSG_LOGOUT_COMPLETE)
        {
            Write((byte)0);
        }

        #endregion
    }
}