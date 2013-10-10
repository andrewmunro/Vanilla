
namespace Vanilla.World.Network
{
    using System.Collections.Generic;

    using Vanilla.Core;
    using Vanilla.Core.Network;

    public class WorldServer : Server
    {
        public WorldServer()
        {
            Router = new WorldRouter();
        }

        public WorldRouter Router { get; private set; }

        public static List<WorldSession> Sessions = new List<WorldSession>();

        public static void TransmitToAll(ServerPacket packet)
        {
            Sessions.FindAll(s => s.Character != null).ForEach(s => s.SendPacket(packet));
        }

        public static WorldSession GetSessionByPlayerName(string playerName)
        {
            return Sessions.Find(user => user.Character.Name.ToLower() == playerName.ToLower());
        }

        public override Session GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
        {
            connectionID++;
            var session = new WorldSession(connectionID, connectionSocket);
            Sessions.Add(session);

            return session;
        }
    }
}
