using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSSetRestStart : ServerPacket
    {
        //TODO Implement
        public PSSetRestStart() : base(WorldOpcodes.SMSG_SET_REST_START)
        {
            Write((byte)0);
        }
    }
}
