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
using Milkshake.Tools.Config;
using Milkshake.Tools.Database;
using Milkshake.Communication.Outgoing.World;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Update;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Game.Handlers;
using Milkshake.Communication.Incoming.Character;

namespace Milkshake
{
    public class MilkShake
    {

        static void Main(string[] args)
        {
            DB.Boot();
            Config.Boot();
            RealmServer realm = new RealmServer();
            WorldServer world = new WorldServer();
            realm.Start(Config.GetValue<int>(ConfigValues.LOGIN, ConfigValues.PORT), Config.GetValue<int>(ConfigValues.LOGIN, ConfigValues.MAX_CONNECTIONS));
            world.Start(Config.GetValue<int>(ConfigValues.WORLD, ConfigValues.PORT), Config.GetValue<int>(ConfigValues.WORLD, ConfigValues.MAX_CONNECTIONS));
            
            LogoutManager.Boot();
            ChatManager.Boot();
            MovementManager.Boot();
            MiscManager.Boot();

            while (true) Console.ReadLine();
        }

    }

    public class RealmServer : MilkTCPListener
    {
        public override ISession GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
        {
            return new RealmSession(connectionID, connectionSocket);
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
