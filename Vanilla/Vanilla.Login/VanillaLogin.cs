namespace Vanilla.Login
{
    using System;
    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Config;
    using Vanilla.Login.Database.Models;
    using Vanilla.Login.Network;

    public class VanillaLogin
    {
        public static int Port
        {
            get
            {
                return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT);
            }
        }

        public static int MaxConnection
        {
            get
            {
                return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS);
            }
        }

        public static LoginServer Server { get; private set; }

        public static LoginDatabase LoginDatabase { get; private set; }

        public static CharacterDatabase CharacterDatabase { get; private set; }

        private static void Main(string[] args)
        {
            LoginDatabase = new LoginDatabase();
            CharacterDatabase = new CharacterDatabase();

            Server = new LoginServer();
            Server.Start(Port, MaxConnection);

            LoginHandler.Boot();

            Console.Read();
        }
    }
}