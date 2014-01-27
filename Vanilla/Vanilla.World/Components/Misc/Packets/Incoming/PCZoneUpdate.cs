namespace Vanilla.World.Components.Misc.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCZoneUpdate : PacketReader
    {
        public PCZoneUpdate(byte[] data)
            : base(data)
        {
            this.ZoneID = this.ReadUInt32();
        }

        public uint ZoneID { get; private set; }
    }
}