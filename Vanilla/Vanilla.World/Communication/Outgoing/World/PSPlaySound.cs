using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World
{
    internal class PSPlaySound : ServerPacket
    {
        public PSPlaySound(uint soundID) : base(WorldOpcodes.SMSG_PLAY_SOUND)
        {
            Write(soundID);
        }
    }
}
