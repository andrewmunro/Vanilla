using System;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Player
{
    using Vanilla.Core.Opcodes;

    public class PSLoginSetTimeSpeed : ServerPacket
    {
        public PSLoginSetTimeSpeed() : base(WorldOpcodes.SMSG_LOGIN_SETTIMESPEED)
        {
            Write((uint)secsToTimeBitFields(DateTime.Now)); // Time
            Write((float)0.01666667f); // Speed
        }

        public static int secsToTimeBitFields(DateTime dateTime)
        {
            return (dateTime.Year - 100) << 24 | dateTime.Month << 20 | (dateTime.Day - 1) << 14 | (int)dateTime.DayOfWeek << 11 | dateTime.Hour << 6 | dateTime.Minute;
        }
    }
}
