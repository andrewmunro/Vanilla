namespace Vanilla.World.Components.Spell.Packets.Outgoing
{
    using System;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal class PSInitialSpells : WorldPacket
    {
        public PSInitialSpells(SpellCollection spellCollection)
            : base(WorldOpcodes.SMSG_INITIAL_SPELLS)
        {
            this.Write((byte)0);
            this.Write((short)spellCollection.Count);

            foreach (var s in spellCollection)
            {
                this.Write((short)s.SpellID);
                this.Write((short)0);
            }

            this.Write((UInt16)spellCollection.Count); // SpellCooldowns count.

            foreach (var s in spellCollection)
            {
                this.Write((uint)s.SpellID);
                this.Write((short)0);
                this.Write((short)s.Catagory);

                if (s.Catagory == 0)
                {
                    this.Write((uint)s.Cooldown);
                    this.Write((uint)0);
                }
                else
                {
                    this.Write((uint)0);
                    this.Write((uint)s.Cooldown);
                }
            }
        }
    }
}