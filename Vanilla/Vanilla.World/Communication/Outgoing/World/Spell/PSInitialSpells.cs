namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    #region

    using System;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Spells;

    #endregion

    internal class PSInitialSpells : ServerPacket
    {
        #region Constructors and Destructors

        public PSInitialSpells(SpellCollection spellCollection)
            : base(WorldOpcodes.SMSG_INITIAL_SPELLS)
        {
            Write((byte)0);
            Write((short)spellCollection.Count);

            foreach (Spell s in spellCollection)
            {
                Write((short)s.SpellID);
                Write((short)0);
            }

            Write((UInt16)spellCollection.Count); // SpellCooldowns count.

            foreach (Spell s in spellCollection)
            {
                Write((uint)s.SpellID);
                Write((short)0);
                Write((short)s.Catagory);

                if (s.Catagory == 0)
                {
                    Write((uint)s.Cooldown);
                    Write((uint)0);
                }
                else
                {
                    Write((uint)0);
                    Write((uint)s.Cooldown);
                }
            }
        }

        #endregion
    }
}