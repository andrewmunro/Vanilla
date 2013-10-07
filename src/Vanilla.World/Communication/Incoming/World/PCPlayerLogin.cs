using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World
{
    public class PCPlayerLogin : PacketReader
    {
        public uint GUID { get; private set; }

        public PCPlayerLogin(byte[] data) : base(data)
        {
            GUID = ReadUInt32();
        }
    }
}
