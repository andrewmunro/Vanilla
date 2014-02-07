namespace Vanilla.World.Game.Entity.Object.Unit
{
    using System;
    using Vanilla.World.Game.Entity;

    public abstract class UnitEntity<TI, TP> : ObjectEntity<TI, TP> where TI : UnitInfo where TP : EntityPacketBuilder
    {
        public String Name { get; private set; }

        protected UnitEntity(ObjectGUID objectGUID) : base(objectGUID)
        {
        }
    }
}
