namespace Vanilla.World.Components.Misc.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCNameQuery : PacketReader
    {
        public uint GUID { get; private set; }

        public PCNameQuery(byte[] data) : base(data)
        {
            this.GUID = this.ReadUInt32();
        }
    }
}
