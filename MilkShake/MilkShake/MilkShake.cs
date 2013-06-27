using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Game.Managers;
using Milkshake.Game.Sessions;
using Milkshake.Network;
using Milkshake.Tools;
using Milkshake.Net;
using Milkshake.Tools.Chat;
using Milkshake.Tools.Config;
using Milkshake.Tools.Database;
using Milkshake.Communication.Outgoing.World;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.Update;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Game.Handlers;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Tools.DBC;
using Milkshake.Tools.DBC.Tables;

namespace Milkshake
{
    public class MilkShake
    {

        static void Main(string[] args)
        {
            /*
            Console.WriteLine(BitConverter.ToUInt32(Helper.HexToByteArray("C7 E8 AB 02 C0 1F"), 0));

            string CreateGameObject = "01 00 00 00 01 02 C7 B6 B0 02 C0 1F 05 52 E4 DD 3D C5 07 5C 5E C3 00 00 00 00 00 00 80 3F 01 00 00 00 F6 82 04 00 01 1F 43 20 01 B6 B0 02 00 00 00 C0 1F 21 00 00 00 B6 B0 02 00 00 00 80 3F C7 0B 00 00 28 00 00 00 01 00 00 00 0F 00 00 00 64 00 00 00 ";
            UpdateReader.ProccessLog(Helper.HexToByteArray(CreateGameObject));
            Console.WriteLine("------------------------------------");
            //UpdateReader.ProccessLog(PSUpdateObject.CreateGameObject(null).Packet);
            */

           // DBCConverter.Convert();

            INI.Boot();
            DB.Boot();
            DBC.Boot();

            LoginServer login = new LoginServer();
            WorldServer world = new WorldServer();

            login.Start(INI.GetValue<int>(ConfigValues.LOGIN, ConfigValues.PORT), INI.GetValue<int>(ConfigValues.LOGIN, ConfigValues.MAX_CONNECTIONS));
            world.Start(INI.GetValue<int>(ConfigValues.WORLD, ConfigValues.PORT), INI.GetValue<int>(ConfigValues.WORLD, ConfigValues.MAX_CONNECTIONS));
            
            LogoutManager.Boot();
            ChatManager.Boot();
            ChatChannelManager.Boot();
            MovementManager.Boot();
            MiscManager.Boot();
            SpellManager.Boot();
            ChatCommandParser.Boot();
            EntityManager.Boot();
            //ZoneHandler.Boot();

            while (true) Console.ReadLine();
        }

    }

    public class LoginServer : MilkTCPListener
    {
        public override ISession GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
        {
            return new LoginSession(connectionID, connectionSocket);
        }
    }

    public class WorldServer : MilkTCPListener
    {
        public static List<WorldSession> Sessions = new List<WorldSession>();
        public int connectionID = 0;

        public override ISession GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
        {
            connectionID++;
            WorldSession session = new WorldSession(connectionID, connectionSocket);
            Sessions.Add(session);

            return session;
        }

        /* Move to WorldServer */
        public static void TransmitToAll(ServerPacket packet)
        {
            WorldServer.Sessions.FindAll(s => s.Character != null).ForEach(s => s.sendPacket(packet));
        }

        public static WorldSession GetSessionByPlayerName(string playerName)
        {
            return WorldServer.Sessions.Find(user => user.Character.Name.ToLower() == playerName.ToLower());
        }

    }
}
