namespace Vanilla.World.Game.Entity.Constants
{
    public enum UnitFlags
    {
        UNIT_FLAG_NONE = 0x00000000,
        UNIT_FLAG_UNK_0 = 0x00000001,
        UNIT_FLAG_NON_ATTACKABLE = 0x00000002,           // not attackable
        UNIT_FLAG_DISABLE_MOVE = 0x00000004,
        UNIT_FLAG_PVP_ATTACKABLE = 0x00000008,           // allow apply pvp rules to attackable state in addition to faction dependent state, UNIT_FLAG_UNKNOWN1 in pre-bc mangos
        UNIT_FLAG_RENAME = 0x00000010,           // rename creature
        UNIT_FLAG_RESTING = 0x00000020,
        UNIT_FLAG_UNK_6 = 0x00000040,
        UNIT_FLAG_OOC_NOT_ATTACKABLE = 0x00000100,           // (OOC Out Of Combat) Can not be attacked when not in combat. Removed if unit for some reason enter combat (flag probably removed for the attacked and it's party/group only)
        UNIT_FLAG_PASSIVE = 0x00000200,           // makes you unable to attack everything. Almost identical to our "civilian"-term. Will ignore it's surroundings and not engage in combat unless "called upon" or engaged by another unit.
        UNIT_FLAG_PVP = 0x00001000,
        UNIT_FLAG_SILENCED = 0x00002000,           // silenced, 2.1.1
        UNIT_FLAG_UNK_14 = 0x00004000,
        UNIT_FLAG_UNK_15 = 0x00008000,
        UNIT_FLAG_UNK_16 = 0x00010000,           // removes attackable icon
        UNIT_FLAG_PACIFIED = 0x00020000,
        UNIT_FLAG_DISABLE_ROTATE = 0x00040000,
        UNIT_FLAG_IN_COMBAT = 0x00080000,
        UNIT_FLAG_NOT_SELECTABLE = 0x02000000,
        UNIT_FLAG_SKINNABLE = 0x04000000,
        UNIT_FLAG_AURAS_VISIBLE = 0x08000000,           // magic detect
        UNIT_FLAG_SHEATHE = 0x40000000,
        // UNIT_FLAG_UNK_31              = 0x80000000           // no affect in 1.12.1

        // [-ZERO] TBC enumerations [?]
        UNIT_FLAG_NOT_ATTACKABLE_1 = 0x00000080,           // ?? (UNIT_FLAG_PVP_ATTACKABLE | UNIT_FLAG_NOT_ATTACKABLE_1) is NON_PVP_ATTACKABLE
        UNIT_FLAG_LOOTING = 0x00000400,           // loot animation
        UNIT_FLAG_PET_IN_COMBAT = 0x00000800,           // in combat?, 2.0.8
        UNIT_FLAG_STUNNED = 0x00040000,           // stunned, 2.1.1
        UNIT_FLAG_TAXI_FLIGHT = 0x00100000,           // disable casting at client side spell not allowed by taxi flight (mounted?), probably used with 0x4 flag
        UNIT_FLAG_DISARMED = 0x00200000,           // disable melee spells casting..., "Required melee weapon" added to melee spells tooltip.
        UNIT_FLAG_CONFUSED = 0x00400000,
        UNIT_FLAG_FLEEING = 0x00800000,
        UNIT_FLAG_PLAYER_CONTROLLED = 0x01000000,           // used in spell Eyes of the Beast for pet... let attack by controlled creature
        //[-ZERO]    UNIT_FLAG_MOUNT                 = 0x08000000,
        UNIT_FLAG_UNK_28 = 0x10000000,
        UNIT_FLAG_UNK_29 = 0x20000000,           // used in Feing Death spell
    };
}
