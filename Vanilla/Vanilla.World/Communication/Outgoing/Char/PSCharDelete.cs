namespace Vanilla.World.Communication.Outgoing.Char
{
    #region

    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSCharDelete : ServerPacket
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