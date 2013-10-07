using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World
{
    public class PCPlayerLogin : PacketReader
    {
        public uint GUID { get; private set; }

        public PCPlayerLogin(byte[] data) : base(data)
        {
            GUID = ReadUInt32();
        }
    }
}
