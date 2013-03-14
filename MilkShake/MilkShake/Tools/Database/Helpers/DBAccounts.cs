using System;
using System.Collections.Generic;
using System.Linq;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database.Helpers
{
    public class DBAccounts
    {
        public static TableQuery<Account> TableQuery { get { return DB.Character.Table<Account>(); } }

        public static List<Account> Accounts { get { return TableQuery.ToList<Account>(); } }

        public static Account GetAccount(String username)
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
            DB.Character.Insert(new Account() { Username = username, Password = password });
        }

        public static void UpdateAccount(Account account)
        {
            DB.Character.Update(account);
        }

        public static void SetSessionKey(String username, String sessionKey)
        {
            Account account = GetAccount(username);
            account.SessionKey = sessionKey;

            UpdateAccount(account);
        }
    }
}
