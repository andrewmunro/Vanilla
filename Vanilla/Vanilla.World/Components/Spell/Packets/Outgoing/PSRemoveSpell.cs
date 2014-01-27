namespace Vanilla.World.Components.Spell.Packets.Outgoing
{
    using System;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal class PSRemoveSpell : WorldPacket
    {
        public PSRemoveSpell(uint spellID)
            : base(WorldOpcodes.SMSG_REMOVED_SPELL)
        {
            this.Write(spellID);
            this.Write((UInt16)0);
        }
    }
}