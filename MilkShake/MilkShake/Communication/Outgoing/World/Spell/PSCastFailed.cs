using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Spell
{
    public class PSCastFailed : ServerPacket
    {
        public PSCastFailed(uint spellID)  : base(WorldOpcodes.SMSG_CAST_FAILED)
        {
            Write((uint)spellID);
        }
    }
}
