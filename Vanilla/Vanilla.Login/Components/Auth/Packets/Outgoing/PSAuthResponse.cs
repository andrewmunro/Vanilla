namespace Vanilla.Login.Components.Auth.Packets.Outgoing
{
    using Vanilla.Core.Constants;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal sealed class PSAuthResponse : WorldPacket
    {
        #region Constructors and Destructors

        public PSAuthResponse() : base(WorldOpcodes.SMSG_AUTH_RESPONSE)
        {
            Write((byte)ResponseCodes.AUTH_OK);
        }

        #endregion
    }
}