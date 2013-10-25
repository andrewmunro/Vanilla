namespace Vanilla.World.Communication.Outgoing.Auth
{
    using Vanilla.Core.Constants;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal sealed class PSAuthResponse : WorldPacket
    {
        public PSAuthResponse()
            : base(WorldOpcodes.SMSG_AUTH_RESPONSE)
        {
            Write((byte)ResponseCodes.AUTH_OK);
        }
    }
}