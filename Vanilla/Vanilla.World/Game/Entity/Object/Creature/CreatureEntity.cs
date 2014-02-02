namespace Vanilla.World.Game.Entity.Object.Creature
{
    using Vanilla.Database.World.Models;
    using Vanilla.World.Game.Entity.Object.Unit;

    public class CreatureEntity : UnitEntity<CreatureInfo, CreaturePacketBuilder>, IUnitEntity
    {
        public CreatureTemplate Template { get; private set; }

        public Creature Creature { get; private set; }

        public string Name { get { return Template.Name; } }

        public CreatureEntity(ObjectGUID objectGUID, Creature databaseCreature, CreatureTemplate template) : base(objectGUID)
        {
            this.Template = template;
            this.Creature = databaseCreature;
        }

        public override void Setup()
        {
            this.Info = new CreatureInfo(this.ObjectGUID, this.Creature, this.Template);

            this.PacketBuilder = new CreaturePacketBuilder(this);

            Location.X = Creature.PositionX;
            Location.Y = Creature.PositionY;
            Location.Z = Creature.PositionZ;
            Location.Orientation = Creature.Orientation;

            base.Setup();
        }
    }
}
