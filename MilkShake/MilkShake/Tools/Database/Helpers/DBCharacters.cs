using System;
using System.Collections.Generic;
using System.Linq;
using Milkshake.Game.Constants;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database.Helpers
{
    public class DBCharacters
    {
        public static TableQuery<Character> CharacterQuery
        {
            get { return DB.Character.Table<Character>(); }
        }

        public static TableQuery<CharacterCreationInfo> CharacterCreationInfoQuery
        {
            get { return DB.World.Table<CharacterCreationInfo>(); }
        }

        public static List<Character> Characters
        {
            get { return CharacterQuery.ToList<Character>(); }
        }

        public static CharacterCreationInfo GetCreationInfo(RaceID raceID, ClassID classID)
        {
            return CharacterCreationInfoQuery.First(m => m.Race == raceID && m.Class == classID);
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

            DB.Character.Insert(character);
        }

        public static void DeleteCharacter(Character character)
        {
            DB.Character.Delete(character);
            DBActionBarButtons.GetActionBarButtons(character).ForEach(b => DB.Character.Delete(b));
            DBSpells.GetCharacterSpells(character).ForEach(s => DB.Character.Delete(s));
            DBChannels.GetChannelCharacters(character).ForEach(c => DB.Character.Delete(c));
        }

        public static void UpdateCharacter(Character character)
        {
            DB.Character.Update(character);
        }
    }
}
