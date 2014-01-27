namespace Vanilla.World.Components.Misc.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCPing : PacketReader
    {
        public PCPing(byte[] data)
            : base(data)
        {
            this.Ping = this.ReadUInt32();
            this.Latency = this.ReadUInt32();
        }

        public uint Latency { get; private set; }
        public uint Ping { get; private set; }
    }
}