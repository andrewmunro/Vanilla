namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal class PSEmote : WorldPacket
    {
        public PSEmote(uint emoteID, ulong GUID)
            : base(WorldOpcodes.SMSG_EMOTE)
        {
            this.Write(emoteID);
            this.Write(GUID);
        }
    }
}