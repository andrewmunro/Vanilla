using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    using Vanilla.Core.Opcodes;

    public class PSCastFailed : ServerPacket
    {
        public PSCastFailed(uint spellID)  : base(WorldOpcodes.SMSG_CAST_FAILED)
        {
            Write((uint)spellID);
        }
    }
}
