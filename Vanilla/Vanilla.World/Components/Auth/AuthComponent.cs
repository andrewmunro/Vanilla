using Vanilla.Login.Database;

namespace Vanilla.World.Components.Auth
{
    using System.Linq;
    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Communication.Outgoing.Auth;
    using Vanilla.World.Components.Auth.Packets.Incoming;
    using Vanilla.World.Network;

    public class AuthComponent : WorldServerComponent
    {
        public AuthComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Router.AddHandler<PCAuthSession>(WorldOpcodes.CMSG_AUTH_SESSION, OnAuthSession);
        }
        
        private void OnAuthSession(WorldSession session, PCAuthSession packet)
        {
            account account = new DatabaseUnitOfWork<LoginDatabase>().GetRepository<account>().SingleOrDefault((a) => a.username == packet.Username);

            session.Account = account;
            session.PacketCrypto = new VanillaCrypt();
            session.PacketCrypto.init(Utils.HexToByteArray(session.Account.sessionkey));
            session.SendPacket(new PSAuthResponse());
        }
    }
}
