namespace Vanilla.World.Game.Entity.Object.Creature
{
    using Vanilla.Database.World.Models;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object.Unit;
    using Vanilla.World.Game.Entity.Tools;

    public class CreatureInfo : UnitInfo
    {
        public CreatureInfo(ObjectGUID objectGUID, Creature creature, CreatureTemplate template) : base(objectGUID)
        {
            DisplayID = NativeDisplayID = creature.ModelID;
            Health = (int)creature.Curhealth;
            MaxHealth = (int)template.Maxhealth;
            Level = template.Maxlevel;

            NPCFlags = (int)template.Npcflag;
            DynamicFlags = (int)template.Dynamicflags;
            UnitFlags = (int)template.UnitFlags;
            FactionTemplate = (uint)template.FactionA;
            Entry = template.Entry; //Used to set the creature name.
        }

        [UpdateField(EUnitFields.UNIT_NPC_FLAGS, true, 1)]
        public int NPCFlags { get; set; }

        [UpdateField(EUnitFields.UNIT_DYNAMIC_FLAGS, true, 1)]
        public int DynamicFlags { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_FLAGS, true, 1)]
        public int UnitFlags { get; set; }
    }
}
