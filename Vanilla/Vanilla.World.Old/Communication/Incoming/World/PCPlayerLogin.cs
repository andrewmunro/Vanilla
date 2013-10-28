namespace Vanilla.World.Communication.Incoming.World
{
    using Vanilla.Core.Network.IO;

    public class PCPlayerLogin : PacketReader
    {
        public PCPlayerLogin(byte[] data)
            : base(data)
        {
            this.GUID = ReadUInt32();
        }

        public uint GUID { get; private set; }
    }
}