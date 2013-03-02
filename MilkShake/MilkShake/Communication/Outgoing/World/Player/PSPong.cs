using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Player
{
    public class PSPong : ServerPacket
    {
        public PSPong(uint ping) : base(Opcodes.SMSG_PONG)
        {
            Write((ulong)ping);
        }
    }
}
