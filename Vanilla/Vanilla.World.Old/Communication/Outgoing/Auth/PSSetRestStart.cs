using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal sealed class PSSetRestStart : WorldPacket
    {
        // TODO Implement
        #region Constructors and Destructors

        public PSSetRestStart()
            : base(WorldOpcodes.SMSG_SET_REST_START)
        {
            Write((byte)0);
        }

        #endregion
    }
}