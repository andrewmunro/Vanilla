using System.Linq;
using System.Runtime.ConstrainedExecution;
using Vanilla.Core.Components;
using Vanilla.Core.Logging;
using Vanilla.Login.Components;
using Vanilla.Login.Components.Auth;
using Vanilla.Login.Components.Realm;
using Vanilla.Login.Database.Models;
using Vanilla.Login.Network;

namespace Vanilla.Login
{
    public class VanillaLogin : VanillaComponentBasedCore<LoginServerComponent>
    {
        public LoginServer Server { get; private set; }
        public LoginDatabase LoginDB { get; private set; }

        public VanillaLogin(int port, int maxConnection) : base()
        {
            LoginDB = new LoginDatabase();
            LoginDB.Accounts.ToList(); // Cache Hack

            Server = new LoginServer();

            Components.Add(new AuthComponent(this));
            Components.Add(new RealmComponent(this));

            Server.Start(port, maxConnection);
        }
    }
}
