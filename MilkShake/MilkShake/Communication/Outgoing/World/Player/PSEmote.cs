using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Player
{
    public class PSEmote : ServerPacket
    {
        public PSEmote(int emoteID, int GUID) : base(Opcodes.SMSG_EMOTE)
        {
            Write((UInt32)emoteID);
            Write((ulong)GUID);
        }
    }
}
