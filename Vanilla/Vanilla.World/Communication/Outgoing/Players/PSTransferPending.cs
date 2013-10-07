using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Players
{
    public class PSTransferPending : ServerPacket
    {
        public PSTransferPending(int mapID) : base((WorldOpcodes) WorldOpcodes.SMSG_TRANSFER_PENDING)
        {
            Write(mapID);
        }
    }
}
