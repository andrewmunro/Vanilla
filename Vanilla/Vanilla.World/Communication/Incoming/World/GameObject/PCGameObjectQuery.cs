using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.GameObject
{
    public class PCGameObjectQuery : PacketReader
    {
        public uint EntryID { get; private set; }
        public uint GUID { get; private set; }

        public PCGameObjectQuery(byte[] data) : base(data)
        {
            EntryID = ReadUInt32();
            GUID = ReadUInt32();
        }
    }
}
