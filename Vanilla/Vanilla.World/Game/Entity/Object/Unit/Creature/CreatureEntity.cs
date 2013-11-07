namespace Vanilla.World.Game.Entity.Object.Unit.Creature
{
    using Vanilla.Database.World.Models;

    public class CreatureEntity : UnitEntity<CreatureInfo, CreaturePacketBuilder>
    {
        public CreatureTemplate template { get; private set; }

        public Creature Creature { get; private set; }

        public CreatureEntity(ObjectGUID objectGUID, Creature databaseCreature, CreatureTemplate template) : base(objectGUID)
        {
            this.template = template;
            this.Creature = databaseCreature;
        }

        public override void Setup()
        {
            this.Info = new CreatureInfo(this.ObjectGUID, this.Creature);

            this.PacketBuilder = new CreaturePacketBuilder(this);

            Location.X = Creature.PositionX;
            Location.Y = Creature.PositionY;
            Location.Z = Creature.PositionZ;
            Location.Orientation = Creature.Orientation;

            base.Setup();
        }
    }
}
