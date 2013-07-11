using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.DBC;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Communication.Outgoing.World.Spell
{
    class PSInitialSpells : ServerPacket
    {

        public PSInitialSpells(Character character) : base(WorldOpcodes.SMSG_INITIAL_SPELLS)
        {
            List<CharacterSpell> characterSpells = DBSpells.GetCharacterSpells(character);
            
            Write((byte)0);
            Write((short)characterSpells.Count);

            foreach (var s in characterSpells)
            {
                Write((short)s.SpellID);
                Write((short)0);
            }

            Write((UInt16)characterSpells.Count); //SpellCooldowns count.


            foreach (var s in characterSpells)
            {
                SpellEntry spell = DBC.Spells.GetSpellByID(s.SpellID);

                Write((uint)spell.ID);
                Write((short)0);
                Write((short)spell.Category);

                if (spell.Category == 0)
                {
                    Write((uint)spell.Cooldown);
                    Write((uint)0);
                }
                else
                {
                    Write((uint)0);
                    Write((uint)spell.Cooldown);
                }
            }

        }
    }
}
