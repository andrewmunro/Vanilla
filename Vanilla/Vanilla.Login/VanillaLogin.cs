using Vanilla.Core.Components;
using Vanilla.Login.Components;
using Vanilla.Login.Components.Login;
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
            Server = new LoginServer();

            Components.Add(new AuthComponent(this));
            Components.Add(new RealmComponent(this));

            Server.Start(port, maxConnection);
        }
    }
}
