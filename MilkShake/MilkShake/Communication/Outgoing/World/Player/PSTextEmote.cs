using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Player
{
    public class PSTextEmote : ServerPacket
    {
        public PSTextEmote(int GUID, int emoteID, int textID) : base(Opcodes.SMSG_TEXT_EMOTE)
        {
            Write((ulong)GUID);
            Write((uint)textID);
            Write((uint)emoteID);
            Write((uint)1);
            Write((byte)0);
        }
    }
}
