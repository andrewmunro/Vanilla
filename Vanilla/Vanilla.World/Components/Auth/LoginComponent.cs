namespace Vanilla.World.Components.Auth
{
    using System.Linq;

    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Login.Models;
    using Vanilla.World.Communication.Outgoing.Auth;
    using Vanilla.World.Components.Auth.Packets.Incoming;
    using Vanilla.World.Network;

    public class AuthComponent : WorldServerComponent
    {
        protected IRepository<Account> Accounts { get { return Core.LoginDatabase.GetRepository<Account>(); } }

        public AuthComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Router.AddHandler<PCAuthSession>(WorldOpcodes.CMSG_AUTH_SESSION, OnAuthSession);
        }
        
        private void OnAuthSession(WorldSession session, PCAuthSession packet)
        {
            Account account = Accounts.AsQueryable().ToList().First((a) => a.Username == packet.Username);

            session.Account = account;
            session.PacketCrypto = new VanillaCrypt();
            session.PacketCrypto.init(Utils.HexToByteArray(session.Account.SessionKey));
            session.SendPacket(new PSAuthResponse());
        }
    }
}
