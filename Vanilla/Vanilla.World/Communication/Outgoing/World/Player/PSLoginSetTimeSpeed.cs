namespace Vanilla.World.Communication.Outgoing.World.Player
{
    #region

    using System;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public sealed class PSLoginSetTimeSpeed : ServerPacket
    {
        #region Constructors and Destructors

        public PSLoginSetTimeSpeed()
            : base(WorldOpcodes.SMSG_LOGIN_SETTIMESPEED)
        {
            Write((uint)SecsToTimeBitFields(DateTime.Now)); // Time
            Write(0.01666667f); // Speed
        }

        #endregion

        #region Public Methods and Operators

        public static int SecsToTimeBitFields(DateTime dateTime)
        {
            return (dateTime.Year - 100) << 24 | dateTime.Month << 20 | (dateTime.Day - 1) << 14
                   | (int)dateTime.DayOfWeek << 11 | dateTime.Hour << 6 | dateTime.Minute;
        }

        #endregion
    }
}