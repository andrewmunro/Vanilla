namespace Vanilla.World.Components.Login.Packets.Outgoing
{
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal class PSAccountDataTimes : WorldPacket
    {
        public PSAccountDataTimes()
            : base(WorldOpcodes.SMSG_ACCOUNT_DATA_TIMES)
        {
            //TODO Implement
            this.WriteNullByte(128);
        }
    }
}