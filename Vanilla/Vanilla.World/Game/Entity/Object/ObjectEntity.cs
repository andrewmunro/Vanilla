namespace Vanilla.World.Game.Entity.Object
{
    using System.Collections.Generic;

    using Vanilla.Core.Tools;
    using Vanilla.World.Components.Entity;

    public abstract class ObjectEntity<TI, TP> : Entity<TI, TP> where TI : ObjectInfo where TP : EntityPacketBuilder
    {
        public Location Location { get; set; }

        public EntityChunk CurrentChunk { get; set; }

        public List<EntityChunk> SubscribedChunks { get; set; }

        public ObjectEntity(ObjectGUID objectGUID) : base(objectGUID)
        {
            this.Location = new Location();
        }
    }
}
