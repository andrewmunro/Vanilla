using Vanilla.World.Database;

namespace Vanilla.World.Game.Entity.Object.Creature
{
    using Vanilla.World.Game.Entity.Object.Unit;

    public class CreatureEntity : UnitEntity<CreatureInfo, CreaturePacketBuilder>, IUnitEntity
    {
        public creature_template Template { get; private set; }

        public creature Creature { get; private set; }

        public string Name { get { return Template.name; } }

        public CreatureEntity(ObjectGUID objectGUID, creature databaseCreature, creature_template template)
            : base(objectGUID)
        {
            this.Template = template;
            this.Creature = databaseCreature;
        }

        public override void Setup()
        {
            this.Info = new CreatureInfo(this.ObjectGUID, this.Creature, this.Template);

            this.PacketBuilder = new CreaturePacketBuilder(this);

            Location.X = Creature.position_x;
            Location.Y = Creature.position_y;
            Location.Z = Creature.position_z;
            Location.Orientation = Creature.orientation;

            base.Setup();
        }
    }
}
