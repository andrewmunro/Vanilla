namespace Vanilla.World.Game.Entity.Object.Unit.Creature
{
    using Vanilla.Database.World.Models;

    public class CreatureEntity : UnitEntity<CreatureInfo, CreaturePacketBuilder>
    {
        public Creature Creature { get; set; }

        public CreatureEntity(ObjectGUID objectGUID, Creature databaseCreature) : base(objectGUID)
        {
            this.Creature = databaseCreature;
        }

        public override void Setup()
        {
            this.Info = new CreatureInfo(this.ObjectGUID, this.Creature);

            this.PacketBuilder = new CreaturePacketBuilder(this);

            base.Setup();
        }
    }
}
