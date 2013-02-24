using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Sessions;
using Milkshake.Game.World.Logout;
using Milkshake.Network;
using Milkshake.Tools;
using Milkshake.Net;
using Milkshake.Tools.Database;
using Milkshake.Communication.Outgoing.World;

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
    }
}
