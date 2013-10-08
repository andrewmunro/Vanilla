namespace Vanilla.Login.Communication.Outgoing.Char
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Constants.Login;

    internal sealed class PSCharDelete : ServerPacket
    {
        #region Constructors and Destructors

        public PSCharDelete(LoginErrorCode code)
            : base((WorldOpcodes)WorldOpcodes.SMSG_CHAR_CREATE)
        {
            Write((byte)code);
        }

        #endregion
    }
}