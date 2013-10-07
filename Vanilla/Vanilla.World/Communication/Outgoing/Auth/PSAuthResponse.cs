using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Game.Constants.Login;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    class PSAuthResponse : ServerPacket
    {
        public PSAuthResponse() : base((WorldOpcodes) WorldOpcodes.SMSG_AUTH_RESPONSE)
        {
            Write((byte)ResponseCodes.AUTH_OK);
        }
    }
}
