using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace Vanilla.World.Tools.Database.Helpers
{
    class DBSpells
    {
        public static TableQuery<CharacterSpell> CharacterSpellQuery
        {
            get { return DB.Character.Table<CharacterSpell>(); }
        }

        public static TableQuery<CharacterCreationSpell> CharacterCreationSpellQuery
        {
            get { return DB.World.Table<CharacterCreationSpell>(); }
        }

        public static List<CharacterSpell> GetCharacterSpells(Character character)
        {

            List<CharacterSpell> result = CharacterSpellQuery.ToList().FindAll(s => s.GUID == character.GUID);
            if (result.Count == 0) 
            {
                List<CharacterCreationSpell> newCharacterSpells = CharacterCreationSpellQuery.Where(s => s.Race == character.Race && s.Class == character.Class).ToList();
                newCharacterSpells.ForEach(s =>
                    {
                        CharacterSpell newSpell = new CharacterSpell() {GUID = character.GUID, SpellID = s.SpellID};
                        DB.Character.Insert(newSpell);
                        result.Add(newSpell);
                    });
            }
            return result;
        }

        public static CharacterSpell GetCharacterSpell(Character character, int spellID)
        {
            return CharacterSpellQuery.First(s => s.GUID == character.GUID && s.SpellID == spellID);
        }

        public static void AddSpell(Character character, int spellID)
        {
            DB.Character.Insert(new CharacterSpell() { GUID = character.GUID, SpellID = spellID });
        }

        public static void RemoveSpell(Character character, int spellID)
        {
            DB.Character.Delete(GetCharacterSpell(character, spellID));
        }
    }
}
