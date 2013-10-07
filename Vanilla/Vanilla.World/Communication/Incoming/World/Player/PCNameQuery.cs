using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.Player
{
    public class PCNameQuery : PacketReader
    {
        public uint GUID { get; private set; }

        public PCNameQuery(byte[] data): base(data)
        {
            GUID = ReadUInt32();
        }
    }
}
