using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    #region

    using System;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSRemoveSpell : WorldPacket
    {
        #region Constructors and Destructors

        public PSRemoveSpell(uint spellID)
            : base(WorldOpcodes.SMSG_REMOVED_SPELL)
        {
            Write(spellID);
            Write((UInt16)0);
        }

        #endregion
    }
}