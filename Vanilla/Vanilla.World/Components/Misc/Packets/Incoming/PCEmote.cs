namespace Vanilla.World.Components.Misc.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCEmote : PacketReader
    {
        public PCEmote(byte[] data)
            : base(data)
        {
            this.EmoteID = this.ReadUInt32();
        }

        public uint EmoteID { get; private set; }
    }
}