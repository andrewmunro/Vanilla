using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    #region

    using System;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public class PSLearnSpell : WorldPacket
    {
        #region Constructors and Destructors

        public PSLearnSpell(uint spellID)
            : base(WorldOpcodes.SMSG_LEARNED_SPELL)
        {
            Write(spellID);
            Write((UInt16)0);
        }

        #endregion
    }
}