using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Player
{
    public class PCEmote : PacketReader
    {
        public uint EmoteID { get; private set; }

        public PCEmote(byte[] data)  : base(data)
        {
            EmoteID = ReadUInt32();
        }
    }
}
