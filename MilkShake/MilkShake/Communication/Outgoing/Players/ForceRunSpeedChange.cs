using System.IO;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Players
{
    public class ForceRunSpeedChange : ServerPacket
    {
        public ForceRunSpeedChange(uint GUID, float speed)  : base(Opcodes.SMSG_FORCE_RUN_SPEED_CHANGE)
        {
            Write((ulong)GUID);
            Write((uint)0);
            Write(speed);
        }
    }
}
