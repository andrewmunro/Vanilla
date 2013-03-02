using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Player
{
    public class PCZoneUpdate : PacketReader
    {
        public uint ZoneID { get; private set; }

        public PCZoneUpdate(byte[] data) : base(data)
        {
            ZoneID = ReadUInt32();
        }
    }
}
