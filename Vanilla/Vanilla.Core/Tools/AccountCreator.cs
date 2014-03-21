using System;
using System.Linq;

using Vanilla.Core.IO;
using Vanilla.Core.Logging;
using Vanilla.Login.Database;

namespace Vanilla.Core.Tools
{
    public class AccountCreator
    {
        public DatabaseUnitOfWork<LoginDatabase> LoginDatabase { get; private set; }

        public IRepository<account> Accounts { get { return LoginDatabase.GetRepository<account>(); } }

        public AccountCreator()
        {
            LoginDatabase = new DatabaseUnitOfWork<LoginDatabase>();
        }

        public void CreateAccount(string username, string password)
        {
            if (Accounts.SingleOrDefault(ac => ac.username == username) != null)
            {
                Log.Print(LogType.Debug, "Account '" + username + "' was not created because it already exists!");
                return;
            }

            var shaPassHash = CalculateShaPassHash(username, password);

            Accounts.Add(new account()
                             {
                                 username = username,
                                 sha_pass_hash = password,
                                 last_ip = "0.0.0.0",
                                 active_realm_id = 0,
                                 email = "",
                                 expansion = 0,
                                 failed_logins = 0,
                                 gmlevel = 0,
                                 joindate = DateTime.Now,
                                 last_login = DateTime.Now,
                                 locale = 0,
                                 locked = 0,
                                 mutetime = 0,
                                 s = null,
                                 sessionkey = null,
                                 v = null
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
