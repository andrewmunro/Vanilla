using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.GameObject
{
    public class PCGameObjectUse : PacketReader
    {
        public PCGameObjectUse(byte[] data) : base(data)
        {
            GUID = ReadUInt64();
        }

        public ulong GUID { get; set; }
    }
}
