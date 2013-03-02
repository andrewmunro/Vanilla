using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Player
{
    public class PCPing : PacketReader
    {
         public uint Ping { get; private set; }
         public uint Latency { get; private set; }

        public PCPing(byte[] data) : base(data)
        {
            Ping = ReadUInt32();
            Latency = ReadUInt32();
        }
    }
}
