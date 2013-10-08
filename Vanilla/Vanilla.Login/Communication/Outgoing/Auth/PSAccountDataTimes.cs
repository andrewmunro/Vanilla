namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    internal class PSAccountDataTimes : ServerPacket
    {
        #region Constructors and Destructors

        public PSAccountDataTimes()
            : base(WorldOpcodes.SMSG_ACCOUNT_DATA_TIMES)
        {
            this.WriteNullByte(128);
        }

        #endregion
    }
}