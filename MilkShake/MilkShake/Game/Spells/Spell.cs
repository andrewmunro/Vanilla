using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.World.Spell;
using Milkshake.Tools.DBC.Tables;

namespace Milkshake.Game.Spells
{
    public class Spell
    {
        public SpellID SpellID { get; private set; }

        public int Catagory { get; private set; }

        public int CooldownCatagory { get; private set; }

        public int Cooldown { get; private set; }

        public string Name { get; private set; }

        public Spell(SpellID spellID, SpellEntry spellEntry)
        {
            SpellID = spellID;
            Name = spellEntry.Name;
            Cooldown = spellEntry.RecoveryTime;
            CooldownCatagory = spellEntry.CategoryRecoveryTime;
            Catagory = spellEntry.Category;
        }
    }
}
