using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database.Helpers
{
    class DBSpells
    {
        public static TableQuery<CharacterSpell> CharacterSpellQuery
        {
            get { return DB.SQLite.Table<CharacterSpell>(); }
        }

        public static TableQuery<CharacterCreationSpell> CharacterCreationSpellQuery
        {
            get { return DB.SQLite.Table<CharacterCreationSpell>(); }
        }

        public static List<CharacterSpell> GetCharacterSpells(Character character)
        {
            
            List<CharacterSpell> result = CharacterSpellQuery.Where(s => s.GUID == character.GUID).ToList();
            if (result.Count == 0) 
            {
                List<CharacterCreationSpell> newCharacterSpells = CharacterCreationSpellQuery.Where(s => s.Race == character.Race && s.Class == character.Class).ToList();
                newCharacterSpells.ForEach(s =>
                    {
                        CharacterSpell newSpell = new CharacterSpell() {GUID = character.GUID, SpellID = s.SpellID};
                        DB.SQLite.Insert(newSpell);
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
            if(GetCharacterSpell(character, spellID) == null) 
                DB.SQLite.Insert(new CharacterSpell() { GUID = character.GUID, SpellID = spellID });
        }

        public static void RemoveSpell(Character character, int spellID)
        {
            DB.SQLite.Delete(GetCharacterSpell(character, spellID));
        }
    }
}
