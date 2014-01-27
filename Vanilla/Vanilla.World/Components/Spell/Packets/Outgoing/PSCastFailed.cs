namespace Vanilla.World.Components.Spell.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public sealed class PSCastFailed : WorldPacket
    {
        public PSCastFailed(uint spellID)
            : base(WorldOpcodes.SMSG_CAST_FAILED)
        {
            this.Write(spellID);
        }
    }
}