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

            RealmServer realm = new RealmServer();
            WorldServer world = new WorldServer();
            world.Start(120, 50);
            realm.Start(3724, 50);           
            
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
