namespace Vanilla.Core.Network.Session
{
    using System.IO;
    using System.Net.Sockets;

    using Vanilla.Core.Logging;
    using Vanilla.Core.Network.IO;

    public abstract class Session : AbstractSession
    {
        public Session(int connectionID, Socket socket) : base(connectionID, socket) { }

        public void SendPacket(PacketWriter packet)
        {
            byte[] endData = FinalisePacket(packet);

            Log.Print(LogType.Packet, "Server -> Client [" + packet.ParseOpcode() + "]");

            SendData(endData);
        }

        public byte[] FinalisePacket(PacketWriter packet)
        {
            BinaryWriter endPacket = new BinaryWriter(new MemoryStream());
            packet.WriteHeader(endPacket);       // Header
            endPacket.Write(packet.PacketData);  // Data

            return (endPacket.BaseStream as MemoryStream).ToArray();
        }
    }
}
