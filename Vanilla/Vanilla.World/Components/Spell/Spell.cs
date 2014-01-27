namespace Vanilla.World.Components.Spell
{
    using Vanilla.Core.Constants.Spell;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.World.Components.Spell.Constants;

    public class Spell
    {
        public SpellID SpellID { get; private set; }

        public int Catagory { get; private set; }

        public int CooldownCatagory { get; private set; }

        public int Cooldown { get; private set; }

        public int Range { get; private set; }

        public bool IsPassive { get; private set; }

        public string Name { get; private set; }

        public Spell(SpellID spellID, SpellEntry spellEntry)
        {
            SpellID = spellID;
            //TODO Fix SpellEntry Name.
            Name = "";
            Cooldown = spellEntry.RecoveryTime;
            CooldownCatagory = spellEntry.CategoryRecoveryTime;
            Catagory = spellEntry.Category;
            Range = spellEntry.rangeIndex > 0 ? spellEntry.rangeIndex : 30;
            IsPassive = spellEntry.Attributes.HasFlag(SpellAttributes.SPELL_ATTR_PASSIVE);
        }
    }
}
