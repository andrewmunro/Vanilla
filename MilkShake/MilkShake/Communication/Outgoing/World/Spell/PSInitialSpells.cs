﻿using System;
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

        public PSInitialSpells(Character character) : base(Opcodes.SMSG_INITIAL_SPELLS)
        {
            List<CharacterSpell> characterSpells = DBSpells.GetCharacterSpells(character);
            
            Write((byte)0);
            Write((UInt16)characterSpells.Count);

            foreach (var s in characterSpells)
            {
                Write((UInt16)s.SpellID);
                Write((UInt16)0);
            }

            Write((UInt16)characterSpells.Count); //SpellCooldowns count.


            foreach (var s in characterSpells)
            {
                SpellEntry spell = DBC.Spells.GetSpellByID(s.SpellID);

                Write((uint)spell.ID);
                Write((UInt16)0);
                Write((UInt16)spell.Category);

                if (spell.Category == 0)
                {
                    Write((UInt32)spell.Cooldown);
                    Write((UInt32)0);
                }
                else
                {
                    Write((UInt32)0);
                    Write((UInt32)spell.Cooldown);
                }
            }

        }
    }
}
