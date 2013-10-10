namespace Vanilla.Login.Components
{
    using Vanilla.Core.Components;
    using Vanilla.Login.Network;

    public class LoginServerComponent : GenericServerComponent<VanillaLogin, LoginServer, LoginRouter>
    {
        public LoginServerComponent(VanillaLogin vanillaLogin) : base(vanillaLogin)
        {
            Server = Core.Server;
            Router = Core.Server.Router;
        }
    }
}
