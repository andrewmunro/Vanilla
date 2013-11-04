namespace Vanilla.World.Components.Login.Packets.Outgoing
{
    using System;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public sealed class PSLoginSetTimeSpeed : WorldPacket
    {
        //TODO Read speed and time from config.
        public PSLoginSetTimeSpeed()
            : base(WorldOpcodes.SMSG_LOGIN_SETTIMESPEED)
        {
            this.Write((uint)SecsToTimeBitFields(DateTime.Now)); // Time
            this.Write(0.01666667f); // 60fps
        }

        public static int SecsToTimeBitFields(DateTime dateTime)
        {
            return (dateTime.Year - 100) << 24 | dateTime.Month << 20 | (dateTime.Day - 1) << 14
                   | (int)dateTime.DayOfWeek << 11 | dateTime.Hour << 6 | dateTime.Minute;
        }
    }
}