using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Players
{
    public class PSTransferPending : ServerPacket
    {
        public PSTransferPending(int mapID) : base(Opcodes.SMSG_TRANSFER_PENDING)
        {
            Write(mapID);
        }
    }
}
