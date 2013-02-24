using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Game.Constants.Game;

namespace Milkshake.Communication.Outgoing.World.Chat
{
    internal class PSMessageChat : BinaryWriter
    {
        public PSMessageChat(ChatMessage type, ChatLanguage language, uint fromGUID, uint toGUID, string message) : base(new MemoryStream())
        {
            Write((byte)type);
            Write((uint)language);
            Write(fromGUID);
            Write(toGUID);
            Write((uint)message.Length);
            Write(Encoding.UTF8.GetBytes(message + '\0'));
        }

        public byte[] Packet
        {
            get { return (BaseStream as MemoryStream).ToArray(); }
        }
    }
}
