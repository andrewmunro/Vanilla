using System;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Spell
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
