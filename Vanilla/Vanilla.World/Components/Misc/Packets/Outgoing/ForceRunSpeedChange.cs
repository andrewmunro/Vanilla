namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public class ForceRunSpeedChange : WorldPacket
    {
        public ForceRunSpeedChange(uint GUID, float speed)
            : base(WorldOpcodes.SMSG_FORCE_RUN_SPEED_CHANGE)
        {
            this.Write((ulong)GUID);
            this.Write((uint)0);
            this.Write(speed);
        }
    }
}