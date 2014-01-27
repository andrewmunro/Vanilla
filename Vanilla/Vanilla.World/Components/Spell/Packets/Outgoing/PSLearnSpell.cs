namespace Vanilla.World.Components.Spell.Packets.Outgoing
{
    using System;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public class PSLearnSpell : WorldPacket
    {
        public PSLearnSpell(uint spellID)
            : base(WorldOpcodes.SMSG_LEARNED_SPELL)
        {
            this.Write(spellID);
            this.Write((UInt16)0);
        }
    }
}