namespace Vanilla.World.Network
{
    using System.Net.Sockets;

    using Vanilla.Core.Network;
    using Vanilla.Core.Network.Session;

    public class WorldServer : Server
    {
        public WorldServer(VanillaWorld core)
        {
            this.Router = new WorldRouter();
            this.Core = core;
        }

        public VanillaWorld Core { get; private set; }

        public WorldRouter Router { get; private set; }

        public override AbstractSession GenerateSession(int connectionID, Socket connectionSocket)
        {
            return new WorldSession(this, Core, connectionID, connectionSocket);
        }
    }
}