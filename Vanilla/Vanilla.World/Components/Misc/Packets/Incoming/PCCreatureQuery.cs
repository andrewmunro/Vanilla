namespace Vanilla.World.Components.Misc.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public sealed class PCCreatureQuery : PacketReader
    {
        public uint Entry { get; private set; }
        public ulong GUID { get; private set; }

        public PCCreatureQuery(byte[] data)
            : base(data)
        {
            Entry = ReadUInt32();
            GUID = ReadUInt64();
        }
    }
}
