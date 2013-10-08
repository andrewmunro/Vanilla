using System;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    using Vanilla.Core.Opcodes;

    public class PSLearnSpell : ServerPacket
    {
        public PSLearnSpell(uint spellID) : base(WorldOpcodes.SMSG_LEARNED_SPELL)
        {
            Write((uint)spellID);
            Write((UInt16)0);
        }
    }
}
