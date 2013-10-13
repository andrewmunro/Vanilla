using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Vanilla.Core.Constants;
using Vanilla.Core.Cryptography;
using Vanilla.Core.Opcodes;
using Vanilla.Login.Components.Auth.Packets.Incoming;
using Vanilla.Login.Components.Auth.Packets.Outgoing;
using Vanilla.Login.Database.Models;
using Vanilla.Login.Network;

namespace Vanilla.Login.Components.Auth
{
    public class AuthComponent : LoginServerComponent
    {
        public AuthComponent(VanillaLogin vanillaLogin) : base(vanillaLogin)
        {
            Router.AddHandler<PCAuthLoginChallenge>(LoginOpcodes.AUTH_LOGIN_CHALLENGE, OnAuthLoginChallenge);
            Router.AddHandler<PCAuthLoginProof>(LoginOpcodes.AUTH_LOGIN_PROOF, OnAuthLoginProof);
        }

        private void OnAuthLoginChallenge(LoginSession session, PCAuthLoginChallenge packet)
        {
            bool accountExists = Core.LoginDatabase.Accounts.Any((a) => a.Username.ToUpper() == packet.Username.ToUpper());

            if (accountExists)
            {
                Account account = Core.LoginDatabase.Accounts.SingleOrDefault((a) => a.Username.ToUpper() == packet.Username.ToUpper());

                // Later on?
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

            //var account = VanillaLogin.LoginDatabase.Accounts.Single(a => a.Username.ToUpper() == session.AccountName.ToUpper());
            //account.SessionKey = Utils.ByteArrayToHex(sessionKey);
            //VanillaLogin.LoginDatabase.SaveChanges();

            session.SendPacket(new PSAuthLoginProof(session.Authenticator));
        }

        
    }
}
