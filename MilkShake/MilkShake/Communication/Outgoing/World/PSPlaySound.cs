using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World
{
    public class PSPlaySound : ServerPacket
    {
        public PSPlaySound(uint soundID) : base(Opcodes.SMSG_MESSAGECHAT)
        {
            Write(soundID);
        }
    }
}
