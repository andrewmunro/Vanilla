using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.Player
{
    public class PCZoneUpdate : PacketReader
    {
        public uint ZoneID { get; private set; }

        public PCZoneUpdate(byte[] data) : base(data)
        {
            ZoneID = ReadUInt32();
        }
    }
}
