using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    class PSSetRestStart : ServerPacket
    {
        //TODO Implement
        public PSSetRestStart() : base((WorldOpcodes) WorldOpcodes.SMSG_SET_REST_START)
        {
            Write((byte)0);
        }
    }
}
