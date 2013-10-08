using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World
{
    using Vanilla.Core.Opcodes;

    internal class PSPlaySound : ServerPacket
    {
        public PSPlaySound(uint soundID) : base(WorldOpcodes.SMSG_PLAY_SOUND)
        {
            Write(soundID);
        }
    }
}
