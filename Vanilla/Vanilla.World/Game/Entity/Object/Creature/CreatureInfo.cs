namespace Vanilla.World.Game.Entity.Object.Creature
{
    using Vanilla.Database.World.Models;
    using Vanilla.World.Game.Entity.Object.Unit;

    public class CreatureInfo : UnitInfo
    {
        public CreatureInfo(ObjectGUID objectGUID, Creature creature) : base(objectGUID)
        {
            this.DisplayID = NativeDisplayID = creature.ModelID;
            this.Health = (int)creature.Curhealth;
        }
    }
}
