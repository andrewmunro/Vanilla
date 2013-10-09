namespace Vanilla.World.Communication.Outgoing.World
{
    #region

    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSPlaySound : ServerPacket
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