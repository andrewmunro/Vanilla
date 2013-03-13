using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Players
{
    public class PSNewWorld : ServerPacket
    {
        public PSNewWorld(int mapID, float X, float Y, float Z, float R) : base(Opcodes.SMSG_NEW_WORLD)
        {
            Write(mapID);
            Write(X);
            Write(Y);
            Write(Z);
            Write(R);
        }
    }
}
