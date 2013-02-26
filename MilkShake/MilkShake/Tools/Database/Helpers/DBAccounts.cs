using System;
using System.Collections.Generic;
using System.Linq;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database.Helpers
{
    public class DBAccounts
    {
        public static TableQuery<Accounts> TableQuery { get { return DB.SQLite.Table<Accounts>(); } }

        public static List<Accounts> Accounts { get { return TableQuery.ToList<Accounts>(); } }

        public static Accounts GetAccount(String username)
        {
            if (Accounts.Count == 0) return null;

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
}
