using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.Network.IO;

namespace Vanilla.World.Components.Chat.Packets.Outgoing
{

    public class PCNameQuery : PacketReader
    {
        public uint GUID { get; private set; }

        public PCNameQuery(byte[] data) : base(data)
        {
            this.GUID = ReadUInt32();
        }
    }
}
