namespace Vanilla.World.Components.Movement.Packets.Outgoing
{
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Entity.Object.Player;

    public class PSMoveKnockBack : WorldPacket
    {
        public PSMoveKnockBack(PlayerEntity player, float vcos, float vsin, float horizontalSpeed, float verticalSpeed)
            : base(WorldOpcodes.SMSG_MOVE_KNOCK_BACK)
        {
            byte[] packedGUID = player.ObjectGUID.GetGuidBytes();
            this.WriteBytes(packedGUID);
            this.Write((uint)0); // Sequence
            this.Write(vcos);
            this.Write(vsin);
            this.Write(horizontalSpeed);
            this.Write(verticalSpeed);
        }
    }
}