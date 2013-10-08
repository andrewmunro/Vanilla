using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Players
{
    using Vanilla.Core.Opcodes;

    public class ForceRunSpeedChange : ServerPacket
    {
        public ForceRunSpeedChange(uint GUID, float speed)  : base((WorldOpcodes) WorldOpcodes.SMSG_FORCE_RUN_SPEED_CHANGE)
        {
            Write((ulong)GUID);
            Write((uint)0);
            Write(speed);
        }
    }
}
