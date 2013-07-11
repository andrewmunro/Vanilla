using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Mail
{
    public class PCGetMailList : PacketReader
    {
        public uint GUID { get; private set; }

        public PCGetMailList(byte[] data) : base(data)
        {
            GUID = ReadUInt32();
        }
    }
}
