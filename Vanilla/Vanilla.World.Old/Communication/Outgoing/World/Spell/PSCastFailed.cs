using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public sealed class PSCastFailed : WorldPacket
    {
        #region Constructors and Destructors

        public PSCastFailed(uint spellID)
            : base(WorldOpcodes.SMSG_CAST_FAILED)
        {
            Write(spellID);
        }

        #endregion
    }
}