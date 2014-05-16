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
    using Vanilla.World.Components.Entity;

    public class WorldServer : Server
    {
        public VanillaWorld Core { get; private set; }

        public WorldRouter Router { get; private set; }

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
                        this.Update();
                        Core.Components.ForEach(c => c.Update());
                        Thread.Sleep(500);
                    }
                };

            Thread updateSessionThread = new Thread(updateLoop);
            updateSessionThread.Start();
        }

        private void Update()
        {
            if (Core.GetComponent<EntityComponent>() != null) Core.GetComponent<EntityComponent>().Update();
            Sessions.ForEach(s => s.Update());
        }

        public override AbstractSession GenerateSession(int connectionID, Socket connectionSocket)
        {
            var session = new WorldSession(this, Core, connectionID, connectionSocket);
            Sessions.Add(session);
            session.OnSessionDisconnect += abstractSession => Disconnect(session);
            return session;
        }

        private void Disconnect(WorldSession session)
        {
            Sessions.Remove(session);
            if(session.Player != null) Core.GetComponent<EntityComponent>().RemovePlayerEntity(session.Player);
        }

        public WorldSession GetSessionByPlayerName(string playerName)
        {
            return Sessions.SingleOrDefault(s => String.Equals(s.Player.Character.name, playerName, StringComparison.CurrentCultureIgnoreCase));
        }

        public void TransmitToAll(WorldPacket packet)
        {
            Sessions.ForEach(s => s.SendPacket(packet));
        }
    }
}