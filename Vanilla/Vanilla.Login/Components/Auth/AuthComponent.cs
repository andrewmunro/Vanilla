using Vanilla.Login.Database;

namespace Vanilla.Login.Components.Auth
{
    using System.Text;

    using Vanilla.Core;
    using Vanilla.Core.Constants;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Components.Auth.Packets.Incoming;
    using Vanilla.Login.Components.Auth.Packets.Outgoing;
    using Vanilla.Login.Network;

    public class AuthComponent : LoginServerComponent
    {
        protected IRepository<account> Accounts { get { return Core.LoginDatabase.GetRepository<account>(); } }

        public AuthComponent(VanillaLogin vanillaLogin) : base(vanillaLogin)
        {
            Router.AddHandler<PCAuthLoginChallenge>(LoginOpcodes.AUTH_LOGIN_CHALLENGE, OnAuthLoginChallenge);
            Router.AddHandler<PCAuthLoginProof>(LoginOpcodes.AUTH_LOGIN_PROOF, OnAuthLoginProof);
        }

        private void OnAuthLoginChallenge(LoginSession session, PCAuthLoginChallenge packet)
        {
            account account = Accounts.SingleOrDefault((a) => a.username.ToUpper() == packet.Username.ToUpper());

            // Todo: Error checking
            if (account != null)
            {
                session.AccountName = packet.Username;

                byte[] userBytes = Encoding.UTF8.GetBytes(account.username.ToUpper());
                byte[] passBytes = Encoding.UTF8.GetBytes(account.sha_pass_hash.ToUpper());

                session.Authenticator = new Authenticator();
                session.Authenticator.CalculateX(userBytes, passBytes);
                session.SendPacket(new PSAuthLoginChallange(session.Authenticator));
            }
            else
            {
                session.SendPacket(new PSAuthLoginChallange(AccountStatus.UnknownAccount));
            }
        }

        private void OnAuthLoginProof(LoginSession session, PCAuthLoginProof packet)
        {
            session.Authenticator.CalculateU(packet.A);
            session.Authenticator.CalculateM2(packet.M1);
            session.Authenticator.CalculateAccountHash();

            byte[] sessionKey = session.Authenticator.SRP6.K;

            account account = Accounts.SingleOrDefault(a => a.username.ToUpper() == session.AccountName.ToUpper());

            if (account != null)
            {
                account.sessionkey = Utils.ByteArrayToHex(sessionKey);
                
                Core.LoginDatabase.SaveChanges();
                session.SendPacket(new PSAuthLoginProof(session.Authenticator));
            }
            else
            {
                session.SendPacket(new PSAuthLoginProof(AccountStatus.UnknownAccount));
            }}

    }
}
