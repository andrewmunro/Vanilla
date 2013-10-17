using System;
using System.Linq;
using Vanilla.Core.IO;
using Vanilla.Login.Database.Models;
using Vanilla.World.Communication.Outgoing.Auth;

namespace Vanilla.World.Components.Auth
{
    using Database.Character.Models;
    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Auth.Packets.Incoming;
    using Vanilla.World.Components.Zone;
    using Vanilla.World.Network;

    public class LoginComponent : WorldServerComponent
    {
        protected IRepository<Account> Accounts { get { return Core.LoginDatabase.GetRepository<Account>(); } }

        public LoginComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
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
