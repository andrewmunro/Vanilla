using Vanilla.Character.Database;
using Vanilla.World.Database;

namespace Vanilla.World.Components.Spell
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.DBC.Structs;
    using Vanilla.Core.IO;
    using Vanilla.World.Components.Spell.Constants;
    using Vanilla.World.Components.Spell.Packets.Outgoing;
    using Vanilla.World.Game.Entity.Object.Player;

    public class SpellCollection : IEnumerable<Spell>
    {
        protected Dictionary<SpellID, Spell> Collection;
        public PlayerEntity Owner { get; private set; }

        private DatabaseUnitOfWork<CharacterDatabase> CharacterDatabase
        {
            get { return Owner.Session.Core.CharacterDatabase; }
        }

        private IRepository<character_spell> CharacterSpells
        {
            get { return CharacterDatabase.GetRepository<character_spell>(); }
        }

        private IRepository<playercreateinfo_spell> PlayerCreateSpells
        {
            get { return Owner.Session.Core.WorldDatabase.GetRepository<playercreateinfo_spell>(); }
        }

        public SpellCollection(PlayerEntity playerEntity)
        {
            Owner = playerEntity;

            Collection = new Dictionary<SpellID, Spell>();
            List<Spell> databaseSpells = GetSpellsFromDatabase(Owner.Character);

            //Must be a new character, get initial spells
            if (databaseSpells.Count == 0)
            {
                GetCharacterCreationSpells().ForEach(s => Collection.Add(s.SpellID, s));
            }
            else
            {
                databaseSpells.ForEach(s => Collection.Add(s.SpellID, s));
            }
        }

        public int Count { get { return Collection.Count; } }

        public void AddSpell(int spellID)
        {
            AddSpell(CreateSpell(spellID));
        }

        public void AddSpell(Spell spell)
        {
            if (Collection.ContainsKey(spell.SpellID)) return;
            Collection.Add(spell.SpellID, spell);

            CharacterSpells.Add(new character_spell() { guid = Owner.ObjectGUID.Low, spell = (long)spell.SpellID });
            CharacterDatabase.SaveChanges();

            Owner.Session.SendPacket(new PSLearnSpell((uint)spell.SpellID));
        }

        public void RemoveSpell(Spell spell)
        {
            if (!Collection.ContainsKey(spell.SpellID)) return;
            Collection.Remove(spell.SpellID);

            CharacterSpells.Delete(new character_spell() { guid = Owner.ObjectGUID.Low, spell = (long)spell.SpellID });
            CharacterDatabase.SaveChanges();

            Owner.Session.SendPacket(new PSRemoveSpell((uint)spell.SpellID));
        }

        private Spell CreateSpell(int spellID)
        {
            SpellEntry spellEntry = Owner.Session.Core.DBC.GetDBC<SpellEntry>().SingleOrDefault(s => s.ID == spellID);
            return new Spell((SpellID)spellID, spellEntry);
        }

        private List<Spell> GetSpellsFromDatabase(character character)
        {
            List<Spell> Spells = new List<Spell>();

            var dbspells = CharacterSpells.Where(cs => cs.guid == character.guid).ToList();

            dbspells.ForEach(characterSpell => Spells.Add(CreateSpell((int)characterSpell.spell)));
            return Spells;
        }

        private List<Spell> GetCharacterCreationSpells()
        {
            List<Spell> result = new List<Spell>();

            List<playercreateinfo_spell> newCharacterSpells = PlayerCreateSpells.Where(s => s.race == Owner.Character.race && s.@class == Owner.Character.@class).ToList();
            newCharacterSpells.ForEach(s =>
                {
                    Spell spell = this.CreateSpell(s.Spell);
                    CharacterSpells.Add(new character_spell() { guid = Owner.ObjectGUID.Low, spell = (long)spell.SpellID });
                    result.Add(spell);
                });

            CharacterDatabase.SaveChanges();
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Spell> GetEnumerator()
        {
            return ((IEnumerable<Spell>)this.Collection.Values).GetEnumerator();
        }
    }
}
