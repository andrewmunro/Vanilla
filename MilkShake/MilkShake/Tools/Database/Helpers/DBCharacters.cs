using System;
using System.Collections.Generic;
using System.Linq;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database.Helpers
{
    public class DBCharacters
    {
        public static TableQuery<Character> TableQuery
        {
            get { return DB.SQLite.Table<Character>(); }
        }

        public static List<Character> Characters
        {
            get { return TableQuery.ToList<Character>(); }
        }

        public static IEnumerable<Character> GetCharacters(int guid)
        {
            return DB.SQLite.Table<Character>().Where(c => c.GUID == guid);
        }

        public static List<Character> GetCharacters(String username)
        {
            int accountID = DBAccounts.GetAccount(username).ID;
            return Characters.FindAll(a => a.AccountID == accountID);
        }

        public static Character GetCharacter(int guid)
        {
            return Characters.Find(c => c.GUID == guid);
        }

        public static void CreateCharacter(Account owner, Character character)
        {
            character.AccountID = owner.ID;

            DB.SQLite.Insert(character);
        }

        public static void DeleteCharacter(Character character)
        {
            DB.SQLite.Delete(character);
        }

        public static void UpdateCharacter(Character character)
        {
            DB.SQLite.Update(character);
        }
    }
}
