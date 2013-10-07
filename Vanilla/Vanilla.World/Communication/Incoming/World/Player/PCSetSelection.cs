using System;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.Player
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
