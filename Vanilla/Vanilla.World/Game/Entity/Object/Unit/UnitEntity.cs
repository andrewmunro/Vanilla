namespace Vanilla.World.Game.Entity.Object.Unit
{
    using System;

    using Vanilla.Core.Tools;
    using Vanilla.World.Game.Entity;

    public abstract class UnitEntity<TI, TP> : ObjectEntity<TI, TP>, IUnitEntity<TI, TP>
        where TI : UnitInfo
        where TP : EntityPacketBuilder
    {
        public String Name { get; private set; }
        public Location Location { get; set; }

        protected UnitEntity(ObjectGUID objectGUID) : base(objectGUID)
        {
        }
    }
}
