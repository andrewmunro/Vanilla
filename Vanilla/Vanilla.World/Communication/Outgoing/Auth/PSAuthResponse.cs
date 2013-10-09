namespace Vanilla.World.Communication.Outgoing.Auth
{
    #region

    using Vanilla.Core.Constants;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

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