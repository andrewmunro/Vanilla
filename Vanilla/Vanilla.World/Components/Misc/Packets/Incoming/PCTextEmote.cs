namespace Vanilla.World.Components.Misc.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCTextEmote : PacketReader
    {
        public PCTextEmote(byte[] data)
            : base(data)
        {
            this.TextID = this.ReadUInt32();
            this.EmoteID = this.ReadUInt32();
            this.GUID = this.ReadInt32();
        }

        public uint EmoteID { get; private set; }
        public int GUID { get; private set; }
        public uint TextID { get; private set; }
    }
}