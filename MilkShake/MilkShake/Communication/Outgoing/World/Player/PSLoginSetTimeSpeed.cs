using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Player
{
    public class PSLoginSetTimeSpeed : ServerPacket
    {
        public PSLoginSetTimeSpeed() : base(Opcodes.SMSG_LOGIN_SETTIMESPEED)
        {
            Write((UInt32)0); // Time
            Write((float)0.01666667f); // Speed
        }
    }
}
