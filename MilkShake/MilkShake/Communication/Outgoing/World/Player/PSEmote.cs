using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Player
{
    class PSEmote : ServerPacket
    {
        public PSEmote(uint emoteID, ulong GUID) : base(WorldOpcodes.SMSG_EMOTE)
        {
            Write(emoteID);
            Write(GUID);
        }
    }
}
