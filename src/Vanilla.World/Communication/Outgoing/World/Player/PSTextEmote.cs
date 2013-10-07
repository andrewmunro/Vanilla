using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Extensions;

namespace Milkshake.Communication.Outgoing.World.Player
{
    public class PSTextEmote : ServerPacket
    {
        public PSTextEmote(int GUID, int emoteID, int textID, string targetName = null) : base(WorldOpcodes.SMSG_TEXT_EMOTE)
        {
            Write((ulong)GUID);
            Write((uint)textID);
            Write((uint)emoteID);

            if (targetName != null)
            {
                Write((uint)targetName.Length);
                Write(Encoding.UTF8.GetBytes(targetName));
            }
            else
            {
                Write((uint)1);
                Write((byte)0);
            }
        }
    }
}
