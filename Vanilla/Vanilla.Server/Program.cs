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
        
        static void Main(string[] args)
        {
            Config.Boot();

            VanillaLogin vanillaLogin = new VanillaLogin(LoginPort, LoginMaxConnection);
            VanillaWorld vanillaWorld = new VanillaWorld(WorldPort, WorldMaxConnection);

            //new BotClient(LoginPort).ConnectToServer();

            while (true) Thread.Sleep(1000);
        }
    }
}
