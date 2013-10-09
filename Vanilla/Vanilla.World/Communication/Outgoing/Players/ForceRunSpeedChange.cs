namespace Vanilla.World.Communication.Outgoing.Players
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public class ForceRunSpeedChange : ServerPacket
    {
        #region Constructors and Destructors

        public ForceRunSpeedChange(uint GUID, float speed)
            : base((WorldOpcodes)WorldOpcodes.SMSG_FORCE_RUN_SPEED_CHANGE)
        {
            Write((ulong)GUID);
            Write((uint)0);
            Write(speed);
        }

        #endregion
    }
}