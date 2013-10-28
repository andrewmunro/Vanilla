namespace Vanilla.World.Components.Login.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public sealed class PCPlayerLogin : PacketReader
    {
        public PCPlayerLogin(byte[] data)
            : base(data)
        {
            this.GUID = this.ReadUInt32();
        }

        public uint GUID { get; private set; }
    }
}