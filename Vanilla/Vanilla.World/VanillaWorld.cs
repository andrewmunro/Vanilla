using System;
using System.Collections.Generic;
using Vanilla.Core;
using Vanilla.Core.Config;
using Vanilla.Core.Network;
using Vanilla.World.Game.Managers;
using Vanilla.World.Tools.Chat;
using Vanilla.World.Tools.DBC;

namespace Vanilla.World
{
    public class VanillaWorld
    {
        static void Main(string[] args)
        {
            Config.Boot();
            DBC.Boot();

            World = new WorldServer();

            World.Start(Config.GetValue<int>(ConfigSections.WORLD, ConfigValues.PORT), Config.GetValue<int>(ConfigSections.WORLD, ConfigValues.MAX_CONNECTIONS));
            
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
            MailManager.Boot();
            GameObjectManager.Boot();

//            Milkshake.Game.Entitys.AIBrainManager.Boot();

            new PlayerManager();
            UnitComponent = new UnitComponent();
            GameObjectComponent =  new GameObjectComponent();
            new WorldManager();
            ScriptManager.Boot();


            while (true) Console.ReadLine();
        }

        public static UnitComponent UnitComponent { get; private set; }
        public static GameObjectComponent GameObjectComponent { get; private set; }

        public static WorldServer World { get; private set; }
    }

    public class WorldServer : Server
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
