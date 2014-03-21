using Vanilla.Character.Database;

namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using System.Text;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public class PSNameQueryResponse : WorldPacket
    {
        private string channel;

        public PSNameQueryResponse(character character)
            : base(WorldOpcodes.SMSG_NAME_QUERY_RESPONSE)
        {
            this.Write((ulong)character.guid);
            this.Write(Encoding.UTF8.GetBytes(character.name + '\0'));
            this.Write((byte)0); // realm name for cross realm BG usage
            this.Write((uint)character.race);
            this.Write((uint)character.guid);
            this.Write((uint)character.@class);
        }
    }
}
