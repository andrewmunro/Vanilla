namespace Vanilla.Server
{
    using System.Threading;
    using Vanilla.Core.Config;
    using Vanilla.Login;
    using Vanilla.World;

    public class Program
    {
        public static int LoginPort { get { return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT); } }

        public static int LoginMaxConnection { get { return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS); } }

        public static int WorldPort { get { return Config.GetValue<int>(ConfigSections.WORLD, ConfigValues.PORT); } }

        public static int WorldMaxConnection { get { return Config.GetValue<int>(ConfigSections.WORLD, ConfigValues.MAX_CONNECTIONS); } }

        public static VanillaWorld VanillaWorld;

        public static VanillaLogin VanillaLogin;
        
        static void Main(string[] args)
        {
            Config.Boot();

            VanillaLogin = new VanillaLogin(LoginPort, LoginMaxConnection);
            VanillaWorld = new VanillaWorld(WorldPort, WorldMaxConnection);

            new LuaManager(VanillaWorld);

            //new BotClient(LoginPort).ConnectToServer();

            while (true) Thread.Sleep(1000);
        }
    }
}
