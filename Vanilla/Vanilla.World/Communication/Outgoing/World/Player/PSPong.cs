namespace Vanilla.World.Communication.Outgoing.World.Player
{
    #region

    using Vanilla.Core.Opcodes;

    #endregion

    public class PSPong : ServerPacket
    {
        #region Constructors and Destructors

        public PSPong(uint ping)
            : base(WorldOpcodes.SMSG_PONG)
        {
            Write((ulong)ping);
        }

        #endregion
    }
}