namespace Vanilla.World.Components.Mail.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCGetMailList : PacketReader
    {
        public PCGetMailList(byte[] data)
            : base(data)
        {
            this.GUID = this.ReadUInt32();
        }

        public uint GUID { get; private set; }
    }
}