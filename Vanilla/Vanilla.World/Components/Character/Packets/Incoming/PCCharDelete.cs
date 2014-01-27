namespace Vanilla.World.Components.Character.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    internal sealed class PCCharDelete : PacketReader
    {
        public PCCharDelete(byte[] data) : base(data)
        {
            GUID = (int)this.ReadUInt64();
        }

        public long GUID { get; private set; }
    }
}