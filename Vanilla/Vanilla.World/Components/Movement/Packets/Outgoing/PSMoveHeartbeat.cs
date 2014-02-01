namespace Vanilla.World.Components.Movement.Packets.Outgoing
{
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Entity.Object.Player;
    using Vanilla.World.Game.Update.Constants;

    public sealed class PSMoveHeartbeat : WorldPacket
    {
        public PSMoveHeartbeat(PlayerEntity player)
            : base(WorldOpcodes.MSG_MOVE_HEARTBEAT)
        {
            this.WritePackedUInt64(player.ObjectGUID.RawGUID);
            this.Write((uint)MovementFlags.MOVEFLAG_NONE);
            this.Write((uint)1); // Time
            this.Write(player.Location.X);
            this.Write(player.Location.Y);
            this.Write(player.Location.Z);
            this.Write(player.Location.Orientation);
            this.Write((uint)0); // ?
        }
    }
}