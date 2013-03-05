using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Communication.Outgoing.World.Spell
{
    class PSLearnSpell : ServerPacket
    {
        public PSLearnSpell(uint spellID) : base(Opcodes.SMSG_LEARNED_SPELL)
        {
            Write((uint)spellID);
            Write((UInt16)0);
        }
    }
}
