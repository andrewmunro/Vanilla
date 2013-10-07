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
using System.Data.Objects;
using System.Linq;
using VanillaDB;
using VanillaDB.Models;

namespace Vanilla.World
{
    public class VanillaWorld
    {
        static void Main(string[] args)
        {
            INI.Boot();

            var now = DateTime.Now;

            WorldDatabase db = new WorldDatabase();

            db.creature_template.Where(c => c.name.Contains("Stormwind")).ToList().ForEach(c => Log.Print(c.name));

            Log.Print((DateTime.Now - now).Milliseconds);

            var now2 = DateTime.Now;

            db.creature_template.Where(c => c.name.Contains("Elder")).ToList().ForEach(c => Log.Print(c.name));

            Log.Print((DateTime.Now - now2).Milliseconds);

            DB.Boot();
            DBC.Boot();
            

            login = new LoginServer();
            world = new WorldServer();

            login.Start(INI.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT), INI.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS));
            world.Start(INI.GetValue<int>(ConfigSections.WORLD, ConfigValues.PORT), INI.GetValue<int>(ConfigSections.WORLD, ConfigValues.MAX_CONNECTIONS));
            
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
