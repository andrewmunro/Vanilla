using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSPlaySound : WorldPacket
    {
        #region Constructors and Destructors

        public PSPlaySound(uint soundID)
            : base(WorldOpcodes.SMSG_PLAY_SOUND)
        {
            Write(soundID);
        }

        #endregion
    }
}