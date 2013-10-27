namespace Vanilla.World.Components.Auth.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public sealed class PCAuthSession : PacketReader
    {
        public PCAuthSession(byte[] data)
            : base(data)
        {
            this.ClientBuild = this.ReadInt32();
            this.Unk2 = this.ReadInt32();
            this.Username = this.ReadCString();
        }

        public string Username { get; private set; }

        public int ClientBuild { get; private set; }

        public int Unk2 { get; private set; }
    }
}