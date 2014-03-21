using System;
using System.Linq;

using Vanilla.Core.IO;
using Vanilla.Core.Logging;
using Vanilla.Database.Login.Models;

namespace Vanilla.Core.Tools
{
    public class AccountCreator
    {
        public DatabaseUnitOfWork<LoginDatabase> LoginDatabase { get; private set; }

        public IRepository<Account> Accounts { get { return LoginDatabase.GetRepository<Account>(); } }

        public AccountCreator()
        {
            LoginDatabase = new DatabaseUnitOfWork<LoginDatabase>();
        }

        public void CreateAccount(string username, string password)
        {
            if (Accounts.SingleOrDefault(ac => ac.Username == username) != null)
            {
                Log.Print(LogType.Debug, "Account '" + username + "' was not created because it already exists!");
                return;
            }

            var shaPassHash = CalculateShaPassHash(username, password);

            Accounts.Add(new Account()
                             {
                                 Username = username,
                                 ShaPassHash = password,
                                 LastIP = "0.0.0.0",
                                 ActiveRealmID = 0,
                                 Email = "",
                                 Expansion = 0,
                                 FailedLogins = 0,
                                 GmLevel = 0,
                                 Joindate = DateTime.Now,
                                 LastLogin = DateTime.Now,
                                 Locale = 0,
                                 Locked = 0,
                                 MuteTime = 0,
                                 S = null,
                                 SessionKey = null,
                                 V = null
                             });

            LoginDatabase.SaveChanges();

            Log.Print(LogType.Debug, "Account '" + username + "' created!");
        }

        private string CalculateShaPassHash(string name, string password)
        {
            string encoded = "";
            try
            {
                System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
                var encoder = new System.Text.ASCIIEncoding();
                byte[] combined = encoder.GetBytes(name.ToUpper() + ":" + password.ToUpper());
                hash.ComputeHash(combined);
                encoded = Convert.ToBase64String(hash.Hash);
            }
            catch (Exception ex)
            {
                string strerr = "Error in HashCode : " + ex.Message;
            }
            return encoded;
        }  
    }
}
