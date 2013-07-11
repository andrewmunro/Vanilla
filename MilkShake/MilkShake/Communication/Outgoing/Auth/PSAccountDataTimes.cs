using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Extensions;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSAccountDataTimes : ServerPacket
    {
        public PSAccountDataTimes() : base(WorldOpcodes.SMSG_ACCOUNT_DATA_TIMES)
        {
            this.WriteNullByte(128);
        }
    }
}
