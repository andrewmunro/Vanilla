using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Player
{
    using Vanilla.Core.Opcodes;

    public class PSPong : ServerPacket
    {
        public PSPong(uint ping) : base(WorldOpcodes.SMSG_PONG)
        {
            Write((ulong)ping);
        }
    }
}
