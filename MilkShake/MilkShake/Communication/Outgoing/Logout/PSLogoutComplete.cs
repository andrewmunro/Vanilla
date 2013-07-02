using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSLogoutComplete : ServerPacket
    {
        public PSLogoutComplete() : base(WorldOpcodes.SMSG_LOGOUT_COMPLETE)
        {
            Write((byte)0);
        }
    }
}
