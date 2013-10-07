using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSLogoutCancelAcknowledgement : ServerPacket
    {
        public PSLogoutCancelAcknowledgement() : base(WorldOpcodes.SMSG_LOGOUT_CANCEL_ACK)
        {
            Write((byte)0);
        }
    }
}
