using System.Security.Cryptography;
using System.Text;
using Vanilla.World.Communication.Incoming.Auth;
using Vanilla.World.Communication.Incoming.World;
using Vanilla.World.Communication.Incoming.World.Auth;
using Vanilla.World.Communication.Outgoing.Auth;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Communication.Outgoing.World.ActionBarButton;
using Vanilla.World.Communication.Outgoing.World.Player;
using Vanilla.World.Communication.Outgoing.World.Update;
using Vanilla.World.Game.Handlers;
using Vanilla.World.Tools;
using Vanilla.World.Tools.Cryptography;
using Vanilla.World.Tools.Database.Helpers;

namespace Vanilla.World.Game.Managers
{
    public class AuthManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCAuthSession>(WorldOpcodes.CMSG_AUTH_SESSION, OnAuthSession);
            WorldDataRouter.AddHandler<PCPlayerLogin>(WorldOpcodes.CMSG_PLAYER_LOGIN, OnPlayerLogin);
            LoginDataRouter.AddHandler<PCAuthLoginChallenge>(LoginOpcodes.AUTH_LOGIN_CHALLENGE, OnAuthLoginChallenge);
            LoginDataRouter.AddHandler<PCAuthLoginProof>(LoginOpcodes.AUTH_LOGIN_PROOF, OnLoginProof);
            LoginDataRouter.AddHandler(LoginOpcodes.REALM_LIST, onRealmList);
            WorldDataRouter.AddHandler(WorldOpcodes.CMSG_UPDATE_ACCOUNT_DATA, onUpdateAccount);
        }

        private static void onRealmList(LoginSession session, byte[] packet)
        {
            session.sendPacket(new PSRealmList());
        }

        private static void OnLoginProof(LoginSession session, PCAuthLoginProof packet)
        {
            session.Srp6.CalculateU(packet.A);
            session.Srp6.CalculateM2(packet.M1);
            CalculateAccountHash(session);

            byte[] sessionKey = session.Srp6.K;

            DBAccounts.SetSessionKey(session.accountName, Helper.ByteArrayToHex(sessionKey));

            session.sendData(new PSAuthLoginProof(session.Srp6));
        }

        private static void OnAuthLoginChallenge(LoginSession session, PCAuthLoginChallenge packet)
        {
            session.accountName = packet.Name;
            Account account = DBAccounts.GetAccount(packet.Name);

            if (account != null)
            {
                byte[] userBytes = Encoding.UTF8.GetBytes(account.Username.ToUpper());
                byte[] passBytes = Encoding.UTF8.GetBytes(account.Password.ToUpper());

                session.Srp6 = new SRP6(false);
                session.Srp6.CalculateX(userBytes, passBytes);
            }

            session.sendData(new PSAuthLoginChallange(session.Srp6));
        }

        private static void onUpdateAccount(WorldSession session, byte[] data)
        {
            //Log.Print(LogType.Map, "Length: " + length + " Real Length: " + _dataBuffer.Length);
            //crypt.decrypt(new byte[(int)2 * 6]);
        }

        private static void OnPlayerLogin(WorldSession session, PCPlayerLogin packet)
        {
            session.Character = DBCharacters.Characters.Find(character => character.GUID == packet.GUID);
            PSUpdateObject playerEntity = PSUpdateObject.CreateOwnCharacterUpdate(session.Character, out session.Entity);
            session.sendPacket(new LoginVerifyWorld(session.Character.MapID, session.Character.X, session.Character.Y, session.Character.Z, 0));
            session.sendPacket(new PSAccountDataTimes());
            session.sendPacket(new PSSetRestStart());
            session.sendPacket(new PSBindPointUpdate());
            session.sendPacket(new PSTutorialFlags());
            SpellManager.SendInitialSpells(session);
            session.sendPacket(new PSActionButtons(session.Character));
            session.sendPacket(new PSInitializeFactions());
            session.sendPacket(new PSLoginSetTimeSpeed());
            session.sendPacket(new PSInitWorldStates());
            session.sendPacket(playerEntity);
            session.Entity.Session = session;
            World.DispatchOnPlayerSpawn(session.Entity);
        }

        private static void OnAuthSession(WorldSession session, PCAuthSession packet)
        {
            session.Account = DBAccounts.GetAccount(packet.AccountName);
            session.crypt = new VanillaCrypt();
            session.crypt.init(Helper.HexToByteArray(session.Account.SessionKey));
            Log.Print(LogType.Debug, "Started Encryption");
            session.sendPacket(new PSAuthResponse());
        }

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
