namespace Vanilla.World.Game.Entity.Object.Unit
{
    using Vanilla.Core.Tools;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Object.Creature;

    public abstract class UnitEntity<TI, TP> : ObjectEntity<TI, TP> where TI : UnitInfo where TP : EntityPacketBuilder
    {
        protected UnitEntity(ObjectGUID objectGUID) : base(objectGUID)
        {
        }
    }
}
