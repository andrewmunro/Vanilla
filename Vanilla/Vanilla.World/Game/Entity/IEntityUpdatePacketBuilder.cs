namespace Vanilla.World.Game.Entity
{
    public interface IEntityUpdatePacketBuilder
    {
        byte[] UpdatePacket();

        byte[] CreatePacket();

        void resetCreatePacket();

        void resetUpdatePacket();
    }
}
