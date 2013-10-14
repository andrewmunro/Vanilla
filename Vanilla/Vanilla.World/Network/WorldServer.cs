namespace Vanilla.World.Network
{
    using System.Net.Sockets;

    using Vanilla.Core.Network;
    using Vanilla.Core.Network.Session;

    public class WorldServer : Server
    {
        public WorldServer()
        {
            this.Router = new WorldRouter();
        }

        public WorldRouter Router { get; private set; }

        public override AbstractSession GenerateSession(int connectionID, Socket connectionSocket)
        {
            return new WorldSession(this, connectionID, connectionSocket);
        }

        public void OnPacket(WorldSession session, byte[] data)
        {
            this.Router.CallHandler(session, data);
        }
    }
}