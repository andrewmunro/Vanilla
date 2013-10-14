using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.Network;

namespace Vanilla.Login.Components.Auth.Packets.Incoming
{
    public class PCAuthLoginBot : PacketReader
    {
        public string Name;

        public PCAuthLoginBot(byte[] data) : base(data)
        {
            Name = ReadCString();
        }
    }
}
