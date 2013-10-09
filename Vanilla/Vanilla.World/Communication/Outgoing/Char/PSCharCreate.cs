namespace Vanilla.World.Communication.Outgoing.Char
{
    #region

    using Vanilla.Core.Constants;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSCharCreate : ServerPacket
    {
        #region Constructors and Destructors

        public PSCharCreate(LoginErrorCode code)
            : base(WorldOpcodes.SMSG_CHAR_CREATE)
        {
            Write((byte)code);
        }

        #endregion
    }
}