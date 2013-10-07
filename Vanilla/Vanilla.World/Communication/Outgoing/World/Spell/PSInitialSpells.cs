using System;
using Vanilla.World.Game.Spells;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    class PSInitialSpells : ServerPacket
    {

        public PSInitialSpells(SpellCollection spellCollection) : base(WorldOpcodes.SMSG_INITIAL_SPELLS)
        {
            Write((byte)0);
            Write((short)spellCollection.Count);

            foreach (var s in spellCollection)
            {
                Write((short)s.SpellID);
                Write((short)0);
            }

            Write((UInt16)spellCollection.Count); //SpellCooldowns count.

            foreach (var s in spellCollection)
            {
                Write((uint)s.SpellID);
                Write((short)0);
                Write((short)s.Catagory);

                if (s.Catagory == 0)
                {
                    Write((uint)s.Cooldown);
                    Write((uint)0);
                }
                else
                {
                    Write((uint)0);
                    Write((uint)s.Cooldown);
                }
            }

        }
    }
}
