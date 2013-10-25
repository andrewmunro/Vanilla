namespace Vanilla.World.Game.Entity.UpdateBuilder
{
    using System.Collections.Generic;

    public abstract class EntityPacketBuilder
    {
        public Queue<UpdateField> UpdateQueue = new Queue<UpdateField>();

        private byte[] cachedUpdatePacket;
        private byte[] cachedCreatePacket;

        public byte[] UpdatePacket()
        {
            if (UpdateQueue.Count == 0 && cachedUpdatePacket != null) return cachedUpdatePacket;
            return cachedUpdatePacket = BuildUpdatePacket();
        }

        public byte[] CreatePacket()
        {
            if (UpdateQueue.Count == 0 && cachedCreatePacket != null) return cachedCreatePacket;
            return cachedCreatePacket = BuildCreatePacket();
        }

        protected abstract byte[] BuildUpdatePacket();

        protected abstract byte[] BuildCreatePacket();
    }
}
