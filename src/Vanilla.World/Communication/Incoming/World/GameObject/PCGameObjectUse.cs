using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.GameObject
{
    public class PCGameObjectUse : PacketReader
    {
        public PCGameObjectUse(byte[] data) : base(data)
        {
            GUID = ReadUInt64();
        }

        public ulong GUID { get; set; }
    }
}
