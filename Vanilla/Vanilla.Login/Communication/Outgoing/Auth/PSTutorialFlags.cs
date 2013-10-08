namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    internal class PSTutorialFlags : ServerPacket
    {
        // TODO Write the uint ids of 8 tutorial values
        #region Constructors and Destructors

        public PSTutorialFlags()
            : base(WorldOpcodes.SMSG_TUTORIAL_FLAGS)
        {
            this.WriteNullUInt(8);
        }

        #endregion
    }
}