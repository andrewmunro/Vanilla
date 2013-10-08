namespace Vanilla.Login
{
    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Config;

    public class VanillaLogin
    {
        public static int PORT              { get { return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT); } }
        public static int MAX_CONNECTION    { get { return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS); } }

        public static LoginServer Login { get; private set; }
        public static CharacterDatabase CharacterDatabase { get; private set; }

        private static void Main(string[] args)
        {
            CharacterDatabase = new CharacterDatabase();

            Login = new LoginServer();
            Login.Start(PORT, MAX_CONNECTION);
        }
    }
}