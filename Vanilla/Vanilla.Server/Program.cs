using System.Threading;
using Vanilla.Core.Config;
using Vanilla.Login;

namespace Vanilla.Server
{
    class Program
    {
        public static int LoginPort { get { return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT); } }
        public static int LoginMaxConnection { get { return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS); } }
        
        static void Main(string[] args)
        {
            Config.Boot();

            VanillaLogin vanillaLogin = new VanillaLogin();
            //worldServer.Start(1337, 20);

            while (true) Thread.Sleep(1000);
        }
    }
}
