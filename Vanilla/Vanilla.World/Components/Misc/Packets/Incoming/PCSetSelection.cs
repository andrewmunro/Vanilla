namespace Vanilla.World.Components.Misc.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCSetSelection : PacketReader
    {
        public PCSetSelection(byte[] data)
            : base(data)
        {
            this.GUID = this.ReadUInt64();
        }
        public ulong GUID { get; private set; }
    }
}