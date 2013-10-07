using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.Mail
{
    public class PCGetMailList : PacketReader
    {
        public uint GUID { get; private set; }

        public PCGetMailList(byte[] data) : base(data)
        {
            GUID = ReadUInt32();
        }
    }
}
