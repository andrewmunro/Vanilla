using System;
using Vanilla.Core.Logging;

namespace Vanilla.Login.Components.Auth
{
    using System.Linq;
    using System.Text;

    using Vanilla.Core;
    using Vanilla.Core.Constants;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Components.Auth.Packets.Incoming;
    using Vanilla.Login.Components.Auth.Packets.Outgoing;
    using Vanilla.Login.Database.Models;
    using Vanilla.Login.Network;

    public class AuthComponent : LoginServerComponent
    {
        protected IRepository<Account> Accounts { get { return Core.LoginDatabase.GetRepository<Account>(); } }

        public AuthComponent(VanillaLogin vanillaLogin) : base(vanillaLogin)
        {
            Router.AddHandler<PCAuthLoginChallenge>(LoginOpcodes.AUTH_LOGIN_CHALLENGE, OnAuthLoginChallenge);
            Router.AddHandler<PCAuthLoginProof>(LoginOpcodes.AUTH_LOGIN_PROOF, OnAuthLoginProof);
            Router.AddHandler<PCAuthLoginBot>(LoginOpcodes.AUTH_LOGIN_BOT, OnAuthLoginBot);
        }

        private void OnAuthLoginBot(LoginSession session, PCAuthLoginBot packet)
        {
            Log.Print("Bot: " + packet.Name);
        }

        private void OnAuthLoginChallenge(LoginSession session, PCAuthLoginChallenge packet)
        {
            bool accountExists = Accounts.AsQueryable().Any((a) => a.Username.ToUpper() == packet.Username.ToUpper());

            if (accountExists)
            {
                Account account = Accounts.SingleOrDefault((a) => a.Username.ToUpper() == packet.Username.ToUpper());

                session.AccountName = packet.Username;

                byte[] userBytes = Encoding.UTF8.GetBytes(account.Username.ToUpper());
                byte[] passBytes = Encoding.UTF8.GetBytes(account.ShaPassHash.ToUpper());

                session.Authenticator = new Authenticator();
                session.Authenticator.CalculateX(userBytes, passBytes);
                session.SendPacket(new PSAuthLoginChallange(session.Authenticator));
            }
            else
            {
                session.SendPacket(new PSAuthLoginChallange(AccountStatus.AccountFrozen));
            }
        }

        private void OnAuthLoginProof(LoginSession session, PCAuthLoginProof packet)
        {
            session.Authenticator.CalculateU(packet.A);
            session.Authenticator.CalculateM2(packet.M1);
            session.Authenticator.CalculateAccountHash();

            byte[] sessionKey = session.Authenticator.SessionKey;

            Account account = Accounts.SingleOrDefault(a => a.Username.ToUpper() == session.AccountName.ToUpper());
            if (account != null)
            {
                account.SessionKey = Utils.ByteArrayToHex(sessionKey);
                Core.LoginDatabase.SaveChanges();
            }

            session.SendPacket(new PSAuthLoginProof(session.Authenticator));
        }

    }
}
