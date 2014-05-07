using Vanilla.Core.IO;
using Vanilla.World.Database;
using Vanilla.World.Network;

namespace Vanilla.World.Game.Entity.Object.Creature
{
    using Vanilla.World.Game.Entity.Object.Unit;

    public class CreatureEntity : UnitEntity<CreatureInfo, CreaturePacketBuilder>, IUnitEntity
    {
        private IRepository<creature_template> CreatureTemplateDatabase { get { return VanillaWorld.WorldDatabase.GetRepository<creature_template>(); } }

        public VanillaWorld VanillaWorld { get; private set; }

        public creature_template Template { get; private set; }

        public creature Creature { get; private set; }

        public AiBrain Brain { get; set; }

        public new string Name { get { return Template.name; } }

        public CreatureEntity(ObjectGUID objectGUID, creature creature, VanillaWorld vanillaWorld)
            : base(objectGUID)
        {
            this.VanillaWorld = vanillaWorld;
            this.Creature = creature;
            this.Template = CreatureTemplateDatabase.SingleOrDefault(ct => ct.entry == creature.id);
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

            Brain = new AiBrain(this);
        }

        public override void OnEntityCreatedForSession(WorldSession session)
        {
            base.OnEntityCreatedForSession(session);

            Brain.StartDatabasePathMovement(session);
        }

    }
}
