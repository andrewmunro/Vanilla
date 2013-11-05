namespace Vanilla.World.Game.Entity.Object.Unit.Creature
{
    public class CreaturePacketBuilder : EntityPacketBuilder
    {
        private CreatureEntity entity;

        public override int DataLength { get { return (int)EUnitFields.PLAYER_END - 0x4; }}

        public CreaturePacketBuilder(CreatureEntity entity)
        {
            this.entity = entity;
        }

        protected override byte[] BuildUpdatePacket()
        {
            throw new System.NotImplementedException();
        }

        protected override byte[] BuildCreatePacket()
        {
            throw new System.NotImplementedException();
        }
    }
}
