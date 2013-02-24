using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Game.Constants.Game;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Chat
{
    public class PSMessageChat : ServerPacket
    {
        public PSMessageChat(ChatMessageType type, ChatMessageLanguage language, uint fromGUID, uint toGUID, string message) : base(Opcodes.SMSG_MESSAGECHAT)
        {
            Write((byte)type);
            Write((uint)language);
            Write(fromGUID);
            Write(toGUID);
            Write((uint)message.Length);
            Write(Encoding.UTF8.GetBytes(message + '\0'));
        }      
    }
}
