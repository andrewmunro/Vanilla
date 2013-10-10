namespace Vanilla.Login
{
    using System.Linq;
    using System.Threading;

    using Vanilla.Core.Components;
    using Vanilla.Login.Components;
    using Vanilla.Login.Components.Auth;
    using Vanilla.Login.Components.Realm;
    using Vanilla.Login.Database.Models;
    using Vanilla.Login.Network;

    public class VanillaLogin : VanillaComponentBasedCore<LoginServerComponent>
    {
        public VanillaLogin(int port, int maxConnection)
        {
            this.LoginDatabase = new LoginDatabase();

            // Entity framework hack to call meta data caching as soon as possible.
            new Thread(() => this.LoginDatabase.Accounts.ToList()).Start();

            Server = new LoginServer();

            Components.Add(new AuthComponent(this));
            Components.Add(new RealmComponent(this));

            Server.Start(port, maxConnection);
        }

        public LoginServer Server { get; private set; }

        public LoginDatabase LoginDatabase { get; private set; }
    }
}
