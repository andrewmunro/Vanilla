using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Login;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSAuthResponse : ServerPacket
    {
        public PSAuthResponse() : base(WorldOpcodes.SMSG_AUTH_RESPONSE)
        {
            Write((byte)ResponseCodes.AUTH_OK);
        }
    }
}
