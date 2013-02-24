using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;

namespace Milkshake.Tools.Database
{
    public class DB
    {
        public static SQLiteConnection SQLite;

        public static TableQuery<Accounts> Accounts { get { return SQLite.Table<Accounts>(); } }

        public static void Boot(string databaseURL = "db.db3")
        {
            SQLite = new SQLiteConnection(databaseURL);
        }
    }

    class DBAccounts
    {
        public static TableQuery<Accounts> TableQuery { get { return DB.SQLite.Table<Accounts>(); } }

        public static List<Accounts> Accounts { get { return TableQuery.ToList<Accounts>(); } } // ?

        public static Accounts GetAccount(String username)
        {
            return Accounts.First(a => a.Username.ToLower() == username.ToLower());
        }

        public static bool Exists(String username)
        {
            return Accounts.First(a => a.Username == username) != null;
        }

        public static void CreateAccount(String username, String password)
        {
            DB.SQLite.Insert(new Accounts() { Username = username, Password = password });
        }

        public static void UpdateAccount(Accounts account)
        {
            DB.SQLite.Update(account);
        }

        public static void SetSessionKey(String username, String sessionKey)
        {
            Accounts account = GetAccount(username);
            account.SessionKey = sessionKey;

            UpdateAccount(account);
        }
    }

    class DBCharacters
    {
        public static TableQuery<Character> TableQuery { get { return DB.SQLite.Table<Character>(); } }

        public static List<Character> Characters { get { return TableQuery.ToList<Character>(); } } // ?

        public static List<Character> GetCharacters(String username)
        {
            int accountID = DBAccounts.GetAccount(username).ID;
            return Characters.FindAll(a => a.OwnerID == accountID);
        }

        public static void CreateCharacter(Accounts owner, Character character)
        {
            character.OwnerID = owner.ID;

            DB.SQLite.Insert(character);
        }

        public static void DeleteCharacter(Character character)
        {
            DB.SQLite.Delete(character);
        }
    }

    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public uint GUID { get; set; }

        public int OwnerID { get; set; }
        public string Name { get; set; }

        public RaceID Race { get; set; }
        public ClassID Class { get; set; }
        public byte Level { get; set; }

        public int MapID { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Rotation { get; set; }

        public Gender Gender { get; set; }
        public byte Skin { get; set; }
        public byte Face { get; set; }
        public byte HairStyle { get; set; }
        public byte HairColor { get; set; }
        public byte Accessory { get; set; }

    }

    public class Accounts
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string SessionKey { get; set; }
    }

  
}
