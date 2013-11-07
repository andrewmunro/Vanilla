﻿namespace Vanilla.World.Game.Entity.Object.Unit.Creature
{
    using Vanilla.Database.World.Models;

    public class CreatureInfo : UnitInfo
    {
        public CreatureInfo(ObjectGUID objectGUID, Creature creature) : base(objectGUID)
        {
            this.DisplayID = NativeDisplayID = creature.ModelID;
            this.Health = (int)creature.Curhealth;
        }
    }
}