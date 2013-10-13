using System;
using System.ServiceModel;
using System.ServiceProcess;

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

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)] 
    public class VanillaLogin : VanillaComponentBasedCore<LoginServerComponent>, ILoginServer
    {
        public VanillaLogin()
        {
            this.LoginDatabase = new LoginDatabase();

            // Entity framework hack to call meta data caching as soon as possible.
            LoginDatabase.Accounts.ToList();

            Server = new LoginServer();

            Components.Add(new AuthComponent(this));
            Components.Add(new RealmComponent(this));

            HelloServiceHost.Main(null);

            Server.Start(100, 20);
        }

        

        public LoginServer Server { get; private set; }

        public LoginDatabase LoginDatabase { get; private set; }

        public void RegisterRealm(string name)
        {
           Console.WriteLine("Hello World!");
        }
    }

    public class HelloServiceHost : ServiceBase
    {
        const string CONSOLE = "console";

        public const string NAME = "HelloWorldService";

        ServiceHost _serviceHost = null;

        public HelloServiceHost()
        {
            ServiceName = NAME;
        }

        public static void Main(VanillaLogin login)
        {
            new HelloServiceHost().ConsoleRun(login);
        }

        private void ConsoleRun(VanillaLogin login)
        {
            Console.WriteLine(string.Format("{0}::starting...", GetType().FullName));

            OnStart(null);

            Console.WriteLine(string.Format("{0}::ready (ENTER to exit)", GetType().FullName));
            //Console.ReadLine();

            //OnStop();

            //Console.WriteLine(string.Format("{0}::stopped", GetType().FullName));
        }

        protected override void OnStart(string[] a)
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }

            _serviceHost = new ServiceHost(typeof(VanillaLogin));
            
            _serviceHost.Open();
            
        }

        protected override void OnStop()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
                _serviceHost = null;
            }
        }
    }
}
