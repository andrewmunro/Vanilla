using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Game.Constants.Login;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Char
{
    class PSCharDelete : ServerPacket
    {
        public PSCharDelete(LoginErrorCode code) : base((WorldOpcodes) WorldOpcodes.SMSG_CHAR_CREATE)
        {
            Write((byte)code);
        }
    }
}
