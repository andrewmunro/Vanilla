namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Constants.Login;

    internal sealed class PSAuthResponse : ServerPacket
    {
        #region Constructors and Destructors

        public PSAuthResponse()
            : base(WorldOpcodes.SMSG_AUTH_RESPONSE)
        {
            Write((byte)ResponseCodes.AUTH_OK);
        }

        #endregion
    }
}