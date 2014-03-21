using Vanilla.World.Database;

namespace Vanilla.World.Game.Entity.Object.Creature
{
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object.Unit;
    using Vanilla.World.Game.Entity.Tools;

    public class CreatureInfo : UnitInfo
    {
        public CreatureInfo(ObjectGUID objectGUID, creature creature, creature_template template) : base(objectGUID)
        {
            DisplayID = NativeDisplayID = creature.modelid;
            Health = (int)creature.curhealth;
            MaxHealth = (int)template.maxhealth;
            Level = template.maxlevel;

            NPCFlags = (int)template.npcflag;
            DynamicFlags = (int)template.dynamicflags;
            UnitFlags = (int)template.unit_flags;
            FactionTemplate = (uint)template.faction_A;
            Entry = template.entry; //Used to set the creature name.
        }

        [UpdateField(EUnitFields.UNIT_NPC_FLAGS, true, 1)]
        public int NPCFlags { get; set; }

        [UpdateField(EUnitFields.UNIT_DYNAMIC_FLAGS, true, 1)]
        public int DynamicFlags { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_FLAGS, true, 1)]
        public int UnitFlags { get; set; }
    }
}
