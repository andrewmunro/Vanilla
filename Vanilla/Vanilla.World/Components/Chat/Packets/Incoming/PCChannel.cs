namespace Vanilla.World.Components.Chat.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    internal class PCChannel : PacketReader
    {
        public PCChannel(byte[] data)
            : base(data)
        {
            this.ChannelName = this.ReadCString();
            this.Password = this.ReadCString();
        }
        public string ChannelName { get; private set; }
        public string Password { get; private set; }
    }
}