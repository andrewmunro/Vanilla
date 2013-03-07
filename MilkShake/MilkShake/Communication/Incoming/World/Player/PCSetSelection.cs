using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Player
{
    public class PCSetSelection : PacketReader
    {
        public UInt64 GUID { get; private set; }

        public PCSetSelection(byte[] data)  : base(data)
        {
            GUID = ReadUInt64();
        }
    }
}
