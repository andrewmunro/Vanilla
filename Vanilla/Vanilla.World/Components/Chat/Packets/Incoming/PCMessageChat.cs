namespace Vanilla.World.Components.Chat.Packets.Incoming
{
    using Vanilla.Core.Network.IO;
    using Vanilla.World.Components.Chat.Constants;

    public class PCMessageChat : PacketReader
    {

        public PCMessageChat(byte[] data)
            : base(data)
        {
            this.Type = (ChatMessageType)this.ReadUInt32();

            this.Language = (ChatMessageLanguage)this.ReadUInt32();

            if (this.Type == ChatMessageType.CHAT_MSG_CHANNEL)
            {
                this.ChannelName = this.ReadCString();
            }

            if (this.Type == ChatMessageType.CHAT_MSG_WHISPER)
            {
                this.To = this.ReadCString();
            }

            this.Message = this.ReadCString();
        }

        public string ChannelName { get; private set; }
        public ChatMessageLanguage Language { get; private set; }
        public string Message { get; private set; }
        public string To { get; private set; }
        public ChatMessageType Type { get; private set; }
    }
}