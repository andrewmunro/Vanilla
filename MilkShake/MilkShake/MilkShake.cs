using System;
using System.Collections.Generic;
using Milkshake.Game.Managers;
using Milkshake.Game.Sessions;
using Milkshake.Network;
using Milkshake.Net;
using Milkshake.Tools.Chat;
using Milkshake.Tools.Config;
using Milkshake.Tools.Database;
using Milkshake.Tools.DBC;
using Milkshake.Tools;

namespace Milkshake
{
    public class MilkShake
    {

        static void Main(string[] args)
        {
            INI.Boot();
            DBConverter.Convert();
            DB.Boot();
            DBC.Boot();

            login = new LoginServer();
            world = new WorldServer();

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
            AuthManager.Boot();
            CharacterManager.Boot();
            //ZoneHandler.Boot();
            PlayerManager.Boot();
            UnitManager.Boot();

            Milkshake.Game.Entitys.AIBrainManager.Boot();

            new PlayerManager();
            UnitComponent = new UnitComponent();
            new GameObjectManager();
            new WorldManager();


            while (true) Console.ReadLine();
        }

        public static UnitComponent UnitComponent { get; private set; }

        public static LoginServer login { get; private set; }
        public static WorldServer world { get; private set; }

    }

    public class LoginServer : MilkTCPListener
    {
        public override Session GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
        {
            return new LoginSession(connectionID, connectionSocket);
        }
    }

    public class WorldServer : MilkTCPListener
    {
        public static List<WorldSession> Sessions = new List<WorldSession>();
        public int connectionID = 0;

        public override Session GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
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
