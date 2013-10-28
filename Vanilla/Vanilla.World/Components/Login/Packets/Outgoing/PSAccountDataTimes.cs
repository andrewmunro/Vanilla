using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    #region

    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSAccountDataTimes : WorldPacket
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