namespace Vanilla.World.Game.Entity
{
    using System.Collections.Generic;

    public abstract class EntityUpdatePacketBuilder
    {
        public abstract byte[] UpdatePacket();

        public abstract byte[] CreatePacket();

        public abstract Queue<UpdateField> UpdateQueue { get; set; }
    }
}
