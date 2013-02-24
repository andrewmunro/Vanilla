using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World
{
    public class PCNameQuery : PacketReader
    {
        public UInt32 GUID { get; private set; }

        public PCNameQuery(byte[] data): base(data)
        {
            GUID = ReadUInt32();
        }
    }
}
