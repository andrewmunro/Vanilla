using Vanilla.Core.Constants;
using Vanilla.Core.Network;
using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;

namespace Vanilla.Login.Components.Auth.Packets.Outgoing
{
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