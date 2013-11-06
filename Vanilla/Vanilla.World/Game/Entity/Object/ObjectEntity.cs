namespace Vanilla.World.Game.Entity.Object
{
    using Vanilla.Core.Tools;

    public abstract class ObjectEntity<TI, TP> : Entity<TI, TP> where TI : ObjectInfo where TP : EntityPacketBuilder
    {
        public Location Location { get; set; }

        public ObjectEntity(ObjectGUID objectGUID) : base(objectGUID)
        {
            this.Location = new Location();
        }
    }
}
