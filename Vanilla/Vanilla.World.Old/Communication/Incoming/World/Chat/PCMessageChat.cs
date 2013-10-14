using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Game.Constants.Game;

namespace Milkshake.Communication.Incoming.World.Chat
{
    public class PCMessageChat : PacketReader
    {
        public ChatMessageType Type { get; private set; }
        public ChatMessageLanguage Language { get; private set; }
        public string To { get; private set; }
        public string ChannelName { get; private set; }
        public string Message { get; private set; }

        public PCMessageChat(byte[] data) : base(data)
        {
            Type = (ChatMessageType)ReadUInt32();
            Language = (ChatMessageLanguage)ReadUInt32();

            if (Type == ChatMessageType.CHAT_MSG_CHANNEL) ChannelName = ReadCString();

            if (Type == ChatMessageType.CHAT_MSG_WHISPER) To = ReadCString();            
            Message = ReadCString();
        }
    }
}
