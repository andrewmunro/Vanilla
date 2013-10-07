using System;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.Auth
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
