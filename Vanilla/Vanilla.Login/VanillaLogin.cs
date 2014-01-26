namespace Vanilla.Login
{
    using System;
    using System.ServiceModel;

    using Vanilla.Core.Components;
    using Vanilla.Core.IO;
    using Vanilla.Database.Login.Models;
    using Vanilla.Login.Components;
    using Vanilla.Login.Components.Auth;
    using Vanilla.Login.Components.Realm;
    using Vanilla.Login.Network;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)] 
    public class VanillaLogin : VanillaComponentBasedCore<LoginServerComponent>, ILoginServer
    {
        public VanillaLogin(int portNumber, int maxConnections)
        {
            LoginDatabase = new DatabaseUnitOfWork<LoginDatabase>();

            // Entity framework hack to call meta data caching as soon as possible.
            var accounts = this.LoginDatabase.GetRepository<Account>();
            accounts.AsQueryable();

            Server = new LoginServer();

            Components.Add(new AuthComponent(this));
            Components.Add(new RealmComponent(this));

            Server.Start(portNumber, maxConnections);
        }

        public LoginServer Server { get; private set; }

        public DatabaseUnitOfWork<LoginDatabase> LoginDatabase { get; private set; }

        public void RegisterRealm(string name)
        {
           Console.WriteLine("Hello World!");
        }
    }
}
