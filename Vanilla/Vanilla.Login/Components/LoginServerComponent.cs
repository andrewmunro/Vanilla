using Vanilla.Core.Components;
using Vanilla.Login.Network;

namespace Vanilla.Login.Components
{
    public class LoginServerComponent : GenericServerComponent<VanillaLogin, LoginServer, LoginRouter>
    {
        public LoginServerComponent(VanillaLogin vanillaLogin) : base(vanillaLogin)
        {
            Server = Core.Server;
            Router = Core.Server.Router;
        }
    }
}
