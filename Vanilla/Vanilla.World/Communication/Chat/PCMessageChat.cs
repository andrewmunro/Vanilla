using Vanilla.Core.Network.IO;

namespace Vanilla.World.Communication.Chat
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.World.Game.Constants.Game.Chat;

    #endregion

    public class PCMessageChat : PacketReader
    {
        #region Constructors and Destructors

        public PCMessageChat(byte[] data)
            : base(data)
        {
            this.Type = (ChatMessageType)ReadUInt32();
            this.Language = (ChatMessageLanguage)ReadUInt32();

            if (this.Type == ChatMessageType.CHAT_MSG_CHANNEL)
            {
                this.ChannelName = ReadCString();
            }

            if (this.Type == ChatMessageType.CHAT_MSG_WHISPER)
            {
                this.To = ReadCString();
            }

            this.Message = ReadCString();
        }

        #endregion

        #region Public Properties

        public string ChannelName { get; private set; }
        public ChatMessageLanguage Language { get; private set; }
        public string Message { get; private set; }
        public string To { get; private set; }
        public ChatMessageType Type { get; private set; }

        #endregion
    }
}