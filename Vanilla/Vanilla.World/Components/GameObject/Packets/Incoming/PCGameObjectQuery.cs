namespace Vanilla.World.Components.GameObject.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCGameObjectQuery : PacketReader
    {
        public PCGameObjectQuery(byte[] data)
            : base(data)
        {
            this.EntryID = this.ReadUInt32();
            this.GUID = this.ReadUInt32();
        }

        public uint EntryID { get; private set; }
        public uint GUID { get; private set; }
    }
}