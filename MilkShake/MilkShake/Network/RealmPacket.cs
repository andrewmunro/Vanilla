using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Game.Constants;

namespace Milkshake.Network
{
    public class RealmPacket : Packet
    {
        public RealmPacket(byte[] data)
            : base(data)
        { }

        public RealmPacket(AuthServerOpCode opCode)
            : base(opCode.Parse(), (byte)opCode)
        { }
    }
}
