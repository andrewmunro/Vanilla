using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Game.Constants;

namespace Milkshake.Network
{
    public class WorldPacket : Packet
    {
        public WorldPacket(byte[] data)
            : base(data)
        { }

        public WorldPacket(AuthServerOpCode opCode)
            : base(opCode.Parse(), (byte)opCode)
        { }
    }
}
