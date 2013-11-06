namespace Vanilla.World.Network
{
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Threading;

    using Vanilla.Core.Network;
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
                        this.Sessions.ForEach(s => s.UpdatePacketBuilder.Update());
                        Thread.Sleep(3000);
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
            return session;
        }
    }
}