using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Player
{
    public class PCAreaTrigger : PacketReader
    {
        public uint TriggerID { get; private set; }

        public PCAreaTrigger(byte[] data) : base(data)
        {
            TriggerID = ReadUInt32();
        }
    }
}
