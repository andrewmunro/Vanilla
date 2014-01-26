using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;

namespace Vanilla.World.Components.Chat.Packets.Outgoing
{
    public class PSNameQueryResponse : WorldPacket
    {
        private string channel;

        public PSNameQueryResponse(Vanilla.Database.Character.Models.Character character)
            : base(WorldOpcodes.SMSG_NAME_QUERY_RESPONSE)
        {
            Write((ulong)character.GUID);
            Write(Encoding.UTF8.GetBytes(character.Name + '\0'));
            Write((byte)0); // realm name for cross realm BG usage
            Write((uint)character.Race);
            Write((uint)character.Gender);
            Write((uint)character.Class);
        }
    }
}
