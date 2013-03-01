using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Player
{
    public class PCTextEmote : PacketReader
    {
        public uint TextID { get; private set; }
        public uint EmoteID { get; private set; }

        public PCTextEmote(byte[] data)  : base(data)
        {
            TextID = ReadUInt32();
            EmoteID = ReadUInt32();
        }
    }
}
