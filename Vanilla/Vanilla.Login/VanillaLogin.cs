using System;
using Vanilla.Login.Database.Models;
using Vanilla.World.Game.Managers;

namespace Vanilla.Login
{
    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Config;

    public class VanillaLogin
    {
        public static int PORT              { get { return 90;/*Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT);*/ } }
        public static int MAX_CONNECTION    { get { return 20;/*Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS);*/ } }

        public static LoginServer Server { get; private set; }
        public static LoginDatabase LoginDatabase { get; private set; }
        public static CharacterDatabase CharacterDatabase { get; private set; }

        private static void Main(string[] args)
        {
            LoginDatabase = new LoginDatabase();
            //CharacterDatabase = new CharacterDatabase();

            Server = new LoginServer();
            Server.Start(PORT, MAX_CONNECTION);

            LoginHandler.Boot();

            Console.Read();
        }
    }
}