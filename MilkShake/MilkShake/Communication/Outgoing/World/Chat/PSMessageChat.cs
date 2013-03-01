using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Game.Constants.Game;
using Milkshake.Network;
using Milkshake.Game.Entitys;
using Milkshake.Communication.Outgoing.World.Update;

namespace Milkshake.Communication.Outgoing.World.Chat
{
    public class PSMessageChat : ServerPacket
    {
        private string channel;

        public PSMessageChat(ChatMessageType type, ChatMessageLanguage language, WorldEntity entity, string message)  : this(type, language, entity.GUID, message)
        {
        }

        public PSMessageChat(ChatMessageType type, ChatMessageLanguage language, ulong GUID, string message, string channelName = null)  : base(Opcodes.SMSG_MESSAGECHAT)
        {
            byte[] packedGUID = PSUpdateObject.GenerateGuidBytes(GUID);

            Write((byte)type);

            Write((uint)language);

            Write((ulong)GUID);

            if (type == ChatMessageType.CHAT_MSG_CHANNEL)
            {
                Write((uint)0);
                Write(Encoding.UTF8.GetBytes(channelName + '\0'));
            }

            if (type == ChatMessageType.CHAT_MSG_SAY || type == ChatMessageType.CHAT_MSG_YELL || type == ChatMessageType.CHAT_MSG_PARTY || type == ChatMessageType.CHAT_MSG_CHANNEL)
                Write((ulong)GUID);

            Write((uint)message.Length);
            Write(Encoding.UTF8.GetBytes(message + '\0'));

            if (type == ChatMessageType.CHAT_MSG_CHANNEL)
            {
                Write((byte)0); //Chat tag
            }
        } 
    }
}
