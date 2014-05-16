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
            MaxHealth = (int)template.MaxLevelHealth;
            Level = template.MaxLevel;

            NPCFlags = (int)template.NpcFlags;
            DynamicFlags = (int)template.DynamicFlags;
            UnitFlag = (int)template.UnitFlags;
            FactionTemplate = (uint)template.FactionAlliance;
            Entry = template.Entry; //Used to set the creature name.

            CombatReach = 30f;
        }

        [UpdateField(EUnitFields.UNIT_NPC_FLAGS, true, 1)]
        public int NPCFlags { get; set; }

        [UpdateField(EUnitFields.UNIT_DYNAMIC_FLAGS, true, 1)]
        public int DynamicFlags { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_COMBATREACH, true, 1)]
        public float CombatReach { get; set; }
    }
}
