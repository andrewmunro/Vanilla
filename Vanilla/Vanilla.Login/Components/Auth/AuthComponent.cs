using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Vanilla.Core.Cryptography;
using Vanilla.Core.Logging;
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
            Account account = Core.LoginDB.Accounts.SingleOrDefault((a) => a.Username.ToUpper() == packet.Name.ToUpper());

            if (account == null)
            {
                Log.Print(LogType.Server, "Account missing");
            }

            if (account != null)
            {
                session.AccountName = packet.Name;

                byte[] userBytes = Encoding.UTF8.GetBytes(account.Username.ToUpper());
                byte[] passBytes = Encoding.UTF8.GetBytes(account.ShaPassHash.ToUpper());

                session.Srp6 = new SRP6(false);
                session.Srp6.CalculateX(userBytes, passBytes);
            }

            session.SendData(new PSAuthLoginChallange(session.Srp6));
        }

        private void OnAuthLoginProof(LoginSession session, PCAuthLoginProof packet)
        {
            session.Srp6.CalculateU(packet.A);
            session.Srp6.CalculateM2(packet.M1);
            CalculateAccountHash(session);

            byte[] sessionKey = session.Srp6.K;

            //var account = VanillaLogin.LoginDatabase.Accounts.Single(a => a.Username.ToUpper() == session.AccountName.ToUpper());
            //account.SessionKey = Utils.ByteArrayToHex(sessionKey);
            //VanillaLogin.LoginDatabase.SaveChanges();

            session.SendData(new PSAuthLoginProof(session.Srp6));
        }

        // Move all this into a Utils of some sort.
        private static void CalculateAccountHash(LoginSession session)
        {
            SHA1 shaM1 = new SHA1CryptoServiceProvider();
            byte[] S = session.Srp6.S;
            var S1 = new byte[16];
            var S2 = new byte[16];

            for (int t = 0; t < 16; t++)
            {
                S1[t] = S[t * 2];
                S2[t] = S[(t * 2) + 1];
            }

            byte[] hashS1 = shaM1.ComputeHash(S1);
            byte[] hashS2 = shaM1.ComputeHash(S2);
            session.SessionKey = new byte[hashS1.Length + hashS2.Length];
            for (int t = 0; t < 20; t++)
            {
                session.SessionKey[t * 2] = hashS1[t];
                session.SessionKey[(t * 2) + 1] = hashS2[t];
            }

            var opad = new byte[64];
            var ipad = new byte[64];

            //Static 16 byte Key located at 0x0088FB3C
            var key = new byte[] { 56, 167, 131, 21, 248, 146, 37, 48, 113, 152, 103, 177, 140, 4, 226, 170 };

            //Fill 64 bytes of same value
            for (int i = 0; i <= 64 - 1; i++)
            {
                opad[i] = 0x05C;
                ipad[i] = 0x036;
            }

            //XOR Values
            for (int i = 0; i <= 16 - 1; i++)
            {
                opad[i] = (byte)(opad[i] ^ key[i]);
                ipad[i] = (byte)(ipad[i] ^ key[i]);
            }

            byte[] buffer1 = Concat(ipad, session.SessionKey);
            byte[] buffer2 = shaM1.ComputeHash(buffer1);

            buffer1 = Concat(opad, buffer2);
            session.SessionKey = shaM1.ComputeHash(buffer1);
        }

        private static byte[] Concat(byte[] a, byte[] b)
        {
            var res = new byte[a.Length + b.Length];
            for (int t = 0; t < a.Length; t++)
            {
                res[t] = a[t];
            }
            for (int t = 0; t < b.Length; t++)
            {
                res[t + a.Length] = b[t];
            }
            return res;
        }
    }
}
