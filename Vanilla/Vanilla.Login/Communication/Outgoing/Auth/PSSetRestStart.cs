namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    internal sealed class PSSetRestStart : ServerPacket
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