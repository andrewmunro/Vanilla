using Vanilla.Core;
using Vanilla.Core.Config;
using Vanilla.Core.Network;

namespace Vanilla.Login
{
    public class VanillaLogin
    {
        static void Main(string[] args)
        {
            Login = new LoginServer();
            Login.Start(Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT), Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS));
        }

        public static LoginServer Login { get; private set; }
    }
}
