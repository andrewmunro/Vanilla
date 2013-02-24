using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Auth
{
    class PCAuthSession : PacketReader
    {
        public Int32 ClientBuild { get; private set; }
        public Int32 Unk2 { get; private set; }
        public string AccountName { get; private set; }

        public PCAuthSession(byte[] data) : base(data)
        {
            ClientBuild = ReadInt32();
            Unk2 = ReadInt32();
            AccountName = ReadCString();
        }
    }
}
