namespace Vanilla.World.Communication.Outgoing.World.Logout
{
    #region

    using System;

    using Vanilla.Core.Opcodes;

    #endregion

    internal class SCLogoutResponse : ServerPacket
    {
        #region Constructors and Destructors

        public SCLogoutResponse()
            : base(WorldOpcodes.SMSG_LOGOUT_RESPONSE)
        {
            Write((UInt32)0);
            Write((byte)0);
        }

        #endregion
    }
}