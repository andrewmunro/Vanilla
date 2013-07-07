﻿using Milkshake.Game.Constants.Login;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Char
{
    class PSCharDelete : ServerPacket
    {
        public PSCharDelete(LoginErrorCode code) : base(WorldOpcodes.SMSG_CHAR_CREATE)
        {
            Write((byte)code);
        }
    }
}