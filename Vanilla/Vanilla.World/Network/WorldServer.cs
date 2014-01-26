namespace Vanilla.World.Network
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Threading;

    using Vanilla.Core.Network;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Network.Session;

    public class WorldServer : Server
    {
        public List<WorldSession> Sessions { get; private set; } 

        public WorldServer(VanillaWorld core)
        {
            this.Router = new WorldRouter();
            this.Core = core;
            Sessions = new List<WorldSession>();

            ThreadStart updateLoop = () =>
                {
                    while (true)
                    {
                        this.Sessions.ToList().ForEach(s => s.UpdatePacketBuilder.Update());
                        Thread.Sleep(5000);
                    }
                };

            Thread updateSessionThread = new Thread(updateLoop);
            updateSessionThread.Start();
        }

        public VanillaWorld Core { get; private set; }

        public WorldRouter Router { get; private set; }

        public override AbstractSession GenerateSession(int connectionID, Socket connectionSocket)
        {
            var session = new WorldSession(this, Core, connectionID, connectionSocket);
            Sessions.Add(session);
            session.OnSessionDisconnect += abstractSession => Sessions.Remove(session);
            return session;
        }

        public WorldSession GetSessionByPlayerName(string playerName)
        {
            return Sessions.Single(s => String.Equals(s.Player.Character.Name, playerName, StringComparison.CurrentCultureIgnoreCase));
        }

        public void TransmitToAll(WorldPacket packet)
        {
            Sessions.ForEach(s => s.SendPacket(packet));
        }
    }
}