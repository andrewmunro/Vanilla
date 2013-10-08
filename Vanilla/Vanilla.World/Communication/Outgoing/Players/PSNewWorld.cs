using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Players
{
    using Vanilla.Core.Opcodes;

    public class PSNewWorld : ServerPacket
    {
        public PSNewWorld(int mapID, float X, float Y, float Z, float R) : base((WorldOpcodes) WorldOpcodes.SMSG_NEW_WORLD)
        {
            Write(mapID);
            Write(X);
            Write(Y);
            Write(Z);
            Write(R);
        }
    }
}
