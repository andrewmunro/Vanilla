using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.Auth;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Communication.Incoming.World;
using Milkshake.Communication.Incoming.World.Auth;
using Milkshake.Communication.Outgoing.Auth;
using Milkshake.Communication.Outgoing.World;
using Milkshake.Communication.Outgoing.World.ActionBarButton;
using Milkshake.Communication.Outgoing.World.Player;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Game.Constants;
using Milkshake.Game.Handlers;
using Milkshake.Game.Sessions;
using Milkshake.Net;
using Milkshake.Network;
using Milkshake.Tools;
using Milkshake.Tools.Cryptography;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Game.Managers
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

            session.sendPacket(new PSAuthLoginProof(session.Srp6));
        }

        private static void OnAuthLoginChallenge(LoginSession session, PCAuthLoginChallenge packet)
        {
            session.accountName = packet.Name;
            Account account = DBAccounts.GetAccount(packet.Name);

            byte[] userBytes = Encoding.UTF8.GetBytes(account.Username.ToUpper());
            byte[] passBytes = Encoding.UTF8.GetBytes(account.Password.ToUpper());

            session.Srp6 = new SRP6(false);
            session.Srp6.CalculateX(userBytes, passBytes);

            session.sendPacket(new PSAuthLoginChallange(session.Srp6));
        }

        private static void onUpdateAccount(WorldSession session, byte[] data)
        {
            //Log.Print(LogType.Map, "Length: " + length + " Real Length: " + _dataBuffer.Length);
            //crypt.decrypt(new byte[(int)2 * 6]);
        }

        private static void OnPlayerLogin(WorldSession session, PCPlayerLogin packet)
        {

            session.Character = DBCharacters.Characters.Find(character => character.GUID == packet.GUID);

            session.sendPacket(WorldOpcodes.SMSG_LOGIN_VERIFY_WORLD, new LoginVerifyWorld(session.Character.MapID, 618.518f, -4251.67f, 38.718f, 0).Packet);

            session.sendHexPacket(WorldOpcodes.SMSG_ACCOUNT_DATA_TIMES, "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ");


            session.sendHexPacket(WorldOpcodes.SMSG_SET_REST_START, "00 00 00 00 ");
            session.sendHexPacket(WorldOpcodes.SMSG_BINDPOINTUPDATE, "48 59 36 C5 71 FD 80 C3 B9 FC 53 42 01 00 00 00 D7 00 00 00 ");
            session.sendHexPacket(WorldOpcodes.SMSG_TUTORIAL_FLAGS, "06 00 40 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ");
            SpellManager.SendInitialSpells(session);
            session.sendPacket(new PSActionButtons(session.Character));

            session.sendHexPacket(WorldOpcodes.SMSG_INITIALIZE_FACTIONS, "40 00 00 00 02 00 00 00 00 00 00 00 00 00 02 00 00 00 00 02 00 00 00 00 10 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00 00 16 00 00 00 00 00 00 00 00 00 08 00 00 00 00 0E 00 00 00 00 09 00 00 00 00 00 00 00 00 00 11 00 00 00 00 11 00 00 00 00 11 00 00 00 00 11 00 00 00 00 06 00 00 00 00 06 00 00 00 00 06 00 00 00 00 06 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 06 00 00 00 00 00 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 04 00 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 14 00 00 00 00 02 00 00 00 00 10 00 00 00 00 00 00 00 00 00 10 00 00 00 00 10 00 00 00 00 06 00 00 00 00 10 00 00 00 00 0E 00 00 00 00 18 00 00 00 00 00 00 00 00 00 10 00 00 00 00 10 00 00 00 00 10 00 00 00 00 02 00 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ");

            //sendHexPacket(WorldOpcodes.SMSG_LOGIN_SETTIMESPEED, "E6 A4 11 0D 8A 88 88 3C ");
            session.sendPacket(new PSLoginSetTimeSpeed());

            session.sendHexPacket(WorldOpcodes.SMSG_INIT_WORLD_STATES, "01 00 00 00 6C 00 AE 07 01 00 32 05 01 00 31 05 00 00 2E 05 00 00 F9 06 00 00 F3 06 00 00 F1 06 00 00 EE 06 00 00 ED 06 00 00 71 05 00 00 70 05 00 00 67 05 01 00 66 05 01 00 50 05 01 00 44 05 00 00 36 05 00 00 35 05 01 00 C6 03 00 00 C4 03 00 00 C2 03 00 00 A8 07 00 00 A3 07 0F 27 74 05 00 00 73 05 00 00 72 05 00 00 6F 05 00 00 6E 05 00 00 6D 05 00 00 6C 05 00 00 6B 05 00 00 6A 05 01 00 69 05 01 00 68 05 01 00 65 05 00 00 64 05 00 00 63 05 00 00 62 05 00 00 61 05 00 00 60 05 00 00 5F 05 00 00 5E 05 00 00 5D 05 00 00 5C 05 00 00 5B 05 00 00 5A 05 00 00 59 05 00 00 58 05 00 00 57 05 00 00 56 05 00 00 55 05 00 00 54 05 01 00 53 05 01 00 52 05 01 00 51 05 01 00 4F 05 00 00 4E 05 00 00 4D 05 01 00 4C 05 00 00 4B 05 00 00 45 05 00 00 43 05 01 00 42 05 00 00 40 05 00 00 3F 05 00 00 3E 05 00 00 3D 05 00 00 3C 05 00 00 3B 05 00 00 3A 05 01 00 39 05 00 00 38 05 00 00 37 05 00 00 34 05 00 00 33 05 00 00 30 05 00 00 2F 05 00 00 2D 05 01 00 16 05 01 00 15 05 00 00 B6 03 00 00 45 07 02 00 36 07 01 00 35 07 01 00 34 07 01 00 33 07 01 00 32 07 01 00 02 07 00 00 01 07 00 00 00 07 00 00 FE 06 00 00 FD 06 00 00 FC 06 00 00 FB 06 00 00 F8 06 00 00 F7 06 00 00 F6 06 00 00 F4 06 D0 07 F2 06 00 00 F0 06 00 00 EF 06 00 00 EC 06 00 00 EA 06 00 00 E9 06 00 00 E8 06 00 00 E7 06 00 00 18 05 00 00 17 05 00 00 03 07 00 00 ");

            session.sendPacket(PSUpdateObject.CreateOwnCharacterUpdate(session.Character, out session.Entity));
            session.Entity.Session = session;
            EntityManager.SpawnPlayer(session.Character);
            EntityManager.SendPlayers(session);

            //ChatManager.SendSytemMessage(session, "You logged in to: " + session.Character.Name + " " + session.Character.Class + " " + session.Character.Race + " GUID:" + Character.GUID);
        }

        private static void OnAuthSession(WorldSession session, PCAuthSession packet)
        {
            session.Account = DBAccounts.GetAccount(packet.AccountName);
            session.crypt = new VanillaCrypt();
            session.crypt.init(Helper.HexToByteArray(session.Account.SessionKey));

            Log.Print(LogType.Debug, "Started Encryption");

            session.sendHexPacket(WorldOpcodes.SMSG_AUTH_RESPONSE, "0C 00 00 00 00 00 00 00 00 00 ");
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
