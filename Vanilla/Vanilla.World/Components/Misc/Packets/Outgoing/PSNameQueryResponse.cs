namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using System.Text;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public class PSNameQueryResponse : WorldPacket
    {
        private string channel;

        public PSNameQueryResponse(Database.Character.Models.Character character)
            : base(WorldOpcodes.SMSG_NAME_QUERY_RESPONSE)
        {
            this.Write((ulong)character.GUID);
            this.Write(Encoding.UTF8.GetBytes(character.Name + '\0'));
            this.Write((byte)0); // realm name for cross realm BG usage
            this.Write((uint)character.Race);
            this.Write((uint)character.Gender);
            this.Write((uint)character.Class);
        }
    }
}
