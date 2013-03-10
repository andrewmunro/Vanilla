using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.GameObject
{
    public class PCGameObjectQuery : PacketReader
    {
        public uint EntryID { get; private set; }
        public uint GUID { get; private set; }

        public PCGameObjectQuery(byte[] data) : base(data)
        {
            EntryID = ReadUInt32();
            GUID = ReadUInt32();
        }
    }
}
