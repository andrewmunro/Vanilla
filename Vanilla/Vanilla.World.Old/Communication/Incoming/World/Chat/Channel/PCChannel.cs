using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Chat.Channel
{
    class PCChannel : PacketReader  
    {
        public string ChannelName { get; private set; }
        public string Password { get; private set; }

        public PCChannel(byte[] data) : base(data)
        {
            ChannelName = ReadCString();
            Password = ReadCString();
        }
    }
}
