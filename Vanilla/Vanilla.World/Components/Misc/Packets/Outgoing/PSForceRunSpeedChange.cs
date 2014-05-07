using Vanilla.World.Game.Entity;

namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public sealed class PSForceRunSpeedChange : WorldPacket
    {
        public PSForceRunSpeedChange(ObjectGUID GUID, float speed)
            : base(WorldOpcodes.SMSG_FORCE_RUN_SPEED_CHANGE)
        {
            this.Write(GUID.RawGUID);
            this.Write((uint)0);
            this.Write(speed);
        }
    }
}