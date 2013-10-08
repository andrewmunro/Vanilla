// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VanillaLogin.cs" company="">
//   
// </copyright>
// <summary>
//   The vanilla login.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login
{
    using Vanilla.Core.Config;

    /// <summary>
    /// The vanilla login.
    /// </summary>
    public class VanillaLogin
    {
        #region Public Properties

        /// <summary>
        /// Gets the login.
        /// </summary>
        public static LoginServer Login { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            Login = new LoginServer();
            Login.Start(
                Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT), 
                Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS));
        }

        #endregion
    }
}