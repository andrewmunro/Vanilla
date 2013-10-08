namespace Vanilla.Login.Communication.Outgoing.Char
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Constants.Login;

    internal sealed class PSCharCreate : ServerPacket
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