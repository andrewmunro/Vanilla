namespace Vanilla.Login
{
    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Config;

    public class VanillaLogin
    {
        #region Public Properties

        public static LoginServer Login { get; private set; }

        public static CharacterDatabase CharacterDatabase { get; private set; }

        #endregion

        #region Methods

        private static void Main(string[] args)
        {
            Login = new LoginServer();
            Login.Start(
                Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT), 
                Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS));

            CharacterDatabase = new CharacterDatabase();
        }

        #endregion
    }
}