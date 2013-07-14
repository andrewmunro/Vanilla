using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Spell
{
    class PSRemoveSpell : ServerPacket
    {
        public PSRemoveSpell(uint spellID) : base(WorldOpcodes.SMSG_REMOVED_SPELL)
        {
            Write((uint)spellID);
            Write((UInt16)0);
        }
    }
}
