using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Game.World.Spell
{
        [Flags]
    public enum SpellAttributes : uint
    {
        SPELL_ATTR_UNK0 = 0x00000001,            // 0
        SPELL_ATTR_RANGED = 0x00000002,            // 1 All ranged abilites have this flag
        SPELL_ATTR_ON_NEXT_SWING_1 = 0x00000004,            // 2 on next swing
        SPELL_ATTR_UNK3 = 0x00000008,            // 3 not set in 2.4.2
        SPELL_ATTR_UNK4 = 0x00000010,            // 4 isAbility
        SPELL_ATTR_TRADESPELL = 0x00000020,            // 5 trade spells, will be added by client to a sublist of profession spell
        SPELL_ATTR_PASSIVE = 0x00000040,            // 6 Passive spell
        SPELL_ATTR_UNK7 = 0x00000080,            // 7 can't be linked in chat?
        SPELL_ATTR_UNK8 = 0x00000100,            // 8 hide created item in tooltip (for effect=24)
        SPELL_ATTR_UNK9 = 0x00000200,            // 9
        SPELL_ATTR_ON_NEXT_SWING_2 = 0x00000400,            // 10 on next swing 2
        SPELL_ATTR_UNK11 = 0x00000800,            // 11
        SPELL_ATTR_DAYTIME_ONLY = 0x00001000,            // 12 only useable at daytime, not set in 2.4.2
        SPELL_ATTR_NIGHT_ONLY = 0x00002000,            // 13 only useable at night, not set in 2.4.2
        SPELL_ATTR_INDOORS_ONLY = 0x00004000,            // 14 only useable indoors, not set in 2.4.2
        SPELL_ATTR_OUTDOORS_ONLY = 0x00008000,            // 15 Only useable outdoors.
        SPELL_ATTR_NOT_SHAPESHIFT = 0x00010000,            // 16 Not while shapeshifted
        SPELL_ATTR_ONLY_STEALTHED = 0x00020000,            // 17 Must be in stealth
        SPELL_ATTR_UNK18 = 0x00040000,            // 18
        SPELL_ATTR_LEVEL_DAMAGE_CALCULATION = 0x00080000,            // 19 spelldamage depends on caster level
        SPELL_ATTR_STOP_ATTACK_TARGET = 0x00100000,            // 20 Stop attack after use this spell (and not begin attack if use)
        SPELL_ATTR_IMPOSSIBLE_DODGE_PARRY_BLOCK = 0x00200000,            // 21 Cannot be dodged/parried/blocked
        SPELL_ATTR_SET_TRACKING_TARGET = 0x00400000,            // 22 SetTrackingTarget
        SPELL_ATTR_UNK23 = 0x00800000,            // 23 castable while dead?
        SPELL_ATTR_CASTABLE_WHILE_MOUNTED = 0x01000000,            // 24 castable while mounted
        SPELL_ATTR_DISABLED_WHILE_ACTIVE = 0x02000000,            // 25 Activate and start cooldown after aura fade or remove summoned creature or go
        SPELL_ATTR_UNK26 = 0x04000000,            // 26
        SPELL_ATTR_CASTABLE_WHILE_SITTING = 0x08000000,            // 27 castable while sitting
        SPELL_ATTR_CANT_USED_IN_COMBAT = 0x10000000,            // 28 Cannot be used in combat
        SPELL_ATTR_UNAFFECTED_BY_INVULNERABILITY = 0x20000000,            // 29 unaffected by invulnerability (hmm possible not...)
        SPELL_ATTR_UNK30 = 0x40000000,            // 30 breakable by damage?
        SPELL_ATTR_CANT_CANCEL = 0x80000000,            // 31 positive aura can't be canceled
    };

        [Flags]
    public enum SpellAttributesEx : uint
    {
        SPELL_ATTR_EX_UNK0 = 0x00000001,            // 0
        SPELL_ATTR_EX_DRAIN_ALL_POWER = 0x00000002,            // 1 use all power (Only paladin Lay of Hands and Bunyanize)
        SPELL_ATTR_EX_CHANNELED_1 = 0x00000004,            // 2 channeled 1
        SPELL_ATTR_EX_UNK3 = 0x00000008,            // 3
        SPELL_ATTR_EX_UNK4 = 0x00000010,            // 4
        SPELL_ATTR_EX_NOT_BREAK_STEALTH = 0x00000020,            // 5 Not break stealth
        SPELL_ATTR_EX_CHANNELED_2 = 0x00000040,            // 6 channeled 2
        SPELL_ATTR_EX_NEGATIVE = 0x00000080,            // 7
        SPELL_ATTR_EX_NOT_IN_COMBAT_TARGET = 0x00000100,            // 8 Spell req target not to be in combat state
        SPELL_ATTR_EX_UNK9 = 0x00000200,            // 9
        SPELL_ATTR_EX_NO_THREAT = 0x00000400,            // 10 no generates threat on cast 100%
        SPELL_ATTR_EX_UNK11 = 0x00000800,            // 11
        SPELL_ATTR_EX_UNK12 = 0x00001000,            // 12
        SPELL_ATTR_EX_FARSIGHT = 0x00002000,            // 13 related to farsight
        SPELL_ATTR_EX_UNK14 = 0x00004000,            // 14
        SPELL_ATTR_EX_DISPEL_AURAS_ON_IMMUNITY = 0x00008000,            // 15 remove auras on immunity
        SPELL_ATTR_EX_UNAFFECTED_BY_SCHOOL_IMMUNE = 0x00010000,            // 16 unaffected by school immunity
        SPELL_ATTR_EX_UNK17 = 0x00020000,            // 17 for auras SPELL_AURA_TRACK_CREATURES, SPELL_AURA_TRACK_RESOURCES and SPELL_AURA_TRACK_STEALTHED select non-stacking tracking spells
        SPELL_ATTR_EX_UNK18 = 0x00040000,            // 18
        SPELL_ATTR_EX_UNK19 = 0x00080000,            // 19
        SPELL_ATTR_EX_REQ_TARGET_COMBO_POINTS = 0x00100000,            // 20 Req combo points on target
        SPELL_ATTR_EX_UNK21 = 0x00200000,            // 21
        SPELL_ATTR_EX_REQ_COMBO_POINTS = 0x00400000,            // 22 Use combo points (in 4.x not required combo point target selected)
        SPELL_ATTR_EX_UNK23 = 0x00800000,            // 23
        SPELL_ATTR_EX_UNK24 = 0x01000000,            // 24 Req fishing pole??
        SPELL_ATTR_EX_UNK25 = 0x02000000,            // 25 not set in 2.4.2
        SPELL_ATTR_EX_UNK26 = 0x04000000,            // 26
        SPELL_ATTR_EX_UNK27 = 0x08000000,            // 27
        SPELL_ATTR_EX_UNK28 = 0x10000000,            // 28
        SPELL_ATTR_EX_UNK29 = 0x20000000,            // 29
        SPELL_ATTR_EX_UNK30 = 0x40000000,            // 30 overpower
        SPELL_ATTR_EX_UNK31 = 0x80000000,            // 31
    };

    [Flags]
    public enum SpellAttributesEx2 : uint
    {
        SPELL_ATTR_EX2_UNK0 = 0x00000001,            // 0
        SPELL_ATTR_EX2_UNK1 = 0x00000002,            // 1
        SPELL_ATTR_EX2_CANT_REFLECTED = 0x00000004,            // 2 ? used for detect can or not spell reflected // do not need LOS (e.g. 18220 since 3.3.3)
        SPELL_ATTR_EX2_UNK3 = 0x00000008,            // 3 auto targeting? (e.g. fishing skill enhancement items since 3.3.3)
        SPELL_ATTR_EX2_UNK4 = 0x00000010,            // 4
        SPELL_ATTR_EX2_AUTOREPEAT_FLAG = 0x00000020,            // 5
        SPELL_ATTR_EX2_UNK6 = 0x00000040,            // 6 only usable on tabbed by yourself
        SPELL_ATTR_EX2_UNK7 = 0x00000080,            // 7
        SPELL_ATTR_EX2_UNK8 = 0x00000100,            // 8 not set in 2.4.2
        SPELL_ATTR_EX2_UNK9 = 0x00000200,            // 9
        SPELL_ATTR_EX2_UNK10 = 0x00000400,            // 10
        SPELL_ATTR_EX2_HEALTH_FUNNEL = 0x00000800,            // 11
        SPELL_ATTR_EX2_UNK12 = 0x00001000,            // 12
        SPELL_ATTR_EX2_UNK13 = 0x00002000,            // 13
        SPELL_ATTR_EX2_UNK14 = 0x00004000,            // 14
        SPELL_ATTR_EX2_UNK15 = 0x00008000,            // 15 not set in 2.4.2
        SPELL_ATTR_EX2_UNK16 = 0x00010000,            // 16
        SPELL_ATTR_EX2_UNK17 = 0x00020000,            // 17 suspend weapon timer instead of resetting it, (?Hunters Shot and Stings only have this flag?)
        SPELL_ATTR_EX2_UNK18 = 0x00040000,            // 18 Only Revive pet - possible req dead pet
        SPELL_ATTR_EX2_NOT_NEED_SHAPESHIFT = 0x00080000,            // 19 does not necessary need shapeshift (pre-3.x not have passive spells with this attribute)
        SPELL_ATTR_EX2_UNK20 = 0x00100000,            // 20
        SPELL_ATTR_EX2_DAMAGE_REDUCED_SHIELD = 0x00200000,            // 21 for ice blocks, pala immunity buffs, priest absorb shields, but used also for other spells -> not sure!
        SPELL_ATTR_EX2_UNK22 = 0x00400000,            // 22
        SPELL_ATTR_EX2_UNK23 = 0x00800000,            // 23 Only mage Arcane Concentration have this flag
        SPELL_ATTR_EX2_UNK24 = 0x01000000,            // 24
        SPELL_ATTR_EX2_UNK25 = 0x02000000,            // 25
        SPELL_ATTR_EX2_UNK26 = 0x04000000,            // 26 unaffected by school immunity
        SPELL_ATTR_EX2_UNK27 = 0x08000000,            // 27
        SPELL_ATTR_EX2_UNK28 = 0x10000000,            // 28 no breaks stealth if it fails??
        SPELL_ATTR_EX2_CANT_CRIT = 0x20000000,            // 29 Spell can't crit
        SPELL_ATTR_EX2_UNK30 = 0x40000000,            // 30
        SPELL_ATTR_EX2_FOOD_BUFF = 0x80000000,            // 31 Food or Drink Buff (like Well Fed)
    };

    [Flags]
    public enum SpellAttributesEx3 : uint
    {
        SPELL_ATTR_EX3_UNK0 = 0x00000001,            // 0
        SPELL_ATTR_EX3_UNK1 = 0x00000002,            // 1
        SPELL_ATTR_EX3_UNK2 = 0x00000004,            // 2
        SPELL_ATTR_EX3_UNK3 = 0x00000008,            // 3
        SPELL_ATTR_EX3_UNK4 = 0x00000010,            // 4 Druid Rebirth only this spell have this flag
        SPELL_ATTR_EX3_UNK5 = 0x00000020,            // 5
        SPELL_ATTR_EX3_UNK6 = 0x00000040,            // 6
        SPELL_ATTR_EX3_UNK7 = 0x00000080,            // 7 create a separate (de)buff stack for each caster
        SPELL_ATTR_EX3_TARGET_ONLY_PLAYER = 0x00000100,            // 8 Can target only player
        SPELL_ATTR_EX3_UNK9 = 0x00000200,            // 9
        SPELL_ATTR_EX3_MAIN_HAND = 0x00000400,            // 10 Main hand weapon required
        SPELL_ATTR_EX3_BATTLEGROUND = 0x00000800,            // 11 Can casted only on battleground
        SPELL_ATTR_EX3_CAST_ON_DEAD = 0x00001000,            // 12 target is a dead player (not every spell has this flag)
        SPELL_ATTR_EX3_UNK13 = 0x00002000,            // 13
        SPELL_ATTR_EX3_UNK14 = 0x00004000,            // 14 "Honorless Target" only this spells have this flag
        SPELL_ATTR_EX3_UNK15 = 0x00008000,            // 15 Auto Shoot, Shoot, Throw,  - this is autoshot flag
        SPELL_ATTR_EX3_UNK16 = 0x00010000,            // 16 no triggers effects that trigger on casting a spell??
        SPELL_ATTR_EX3_NO_INITIAL_AGGRO = 0x00020000,            // 17 Causes no aggro if not missed
        SPELL_ATTR_EX3_CANT_MISS = 0x00040000,            // 18 Spell should always hit its target
        SPELL_ATTR_EX3_UNK19 = 0x00080000,            // 19
        SPELL_ATTR_EX3_DEATH_PERSISTENT = 0x00100000,            // 20 Death persistent spells
        SPELL_ATTR_EX3_UNK21 = 0x00200000,            // 21
        SPELL_ATTR_EX3_REQ_WAND = 0x00400000,            // 22 Req wand
        SPELL_ATTR_EX3_UNK23 = 0x00800000,            // 23
        SPELL_ATTR_EX3_REQ_OFFHAND = 0x01000000,            // 24 Req offhand weapon
        SPELL_ATTR_EX3_UNK25 = 0x02000000,            // 25 no cause spell pushback ?
        SPELL_ATTR_EX3_UNK26 = 0x04000000,            // 26
        SPELL_ATTR_EX3_UNK27 = 0x08000000,            // 27
        SPELL_ATTR_EX3_UNK28 = 0x10000000,            // 28
        SPELL_ATTR_EX3_UNK29 = 0x20000000,            // 29
        SPELL_ATTR_EX3_UNK30 = 0x40000000,            // 30
        SPELL_ATTR_EX3_UNK31 = 0x80000000,            // 31
    };

    [Flags]
    public enum SpellAttributesEx4 : uint
    {
        SPELL_ATTR_EX4_UNK0 = 0x00000001,            // 0
        SPELL_ATTR_EX4_UNK1 = 0x00000002,            // 1 proc on finishing move?
        SPELL_ATTR_EX4_UNK2 = 0x00000004,            // 2
        SPELL_ATTR_EX4_UNK3 = 0x00000008,            // 3
        SPELL_ATTR_EX4_UNK4 = 0x00000010,            // 4 This will no longer cause guards to attack on use??
        SPELL_ATTR_EX4_UNK5 = 0x00000020,            // 5
        SPELL_ATTR_EX4_NOT_STEALABLE = 0x00000040,            // 6 although such auras might be dispellable, they cannot be stolen
        SPELL_ATTR_EX4_UNK7 = 0x00000080,            // 7
        SPELL_ATTR_EX4_UNK8 = 0x00000100,            // 8
        SPELL_ATTR_EX4_UNK9 = 0x00000200,            // 9
        SPELL_ATTR_EX4_SPELL_VS_EXTEND_COST = 0x00000400,            // 10 Rogue Shiv have this flag
        SPELL_ATTR_EX4_UNK11 = 0x00000800,            // 11
        SPELL_ATTR_EX4_UNK12 = 0x00001000,            // 12
        SPELL_ATTR_EX4_UNK13 = 0x00002000,            // 13
        SPELL_ATTR_EX4_UNK14 = 0x00004000,            // 14
        SPELL_ATTR_EX4_UNK15 = 0x00008000,            // 15
        SPELL_ATTR_EX4_NOT_USABLE_IN_ARENA = 0x00010000,            // 16 not usable in arena
        SPELL_ATTR_EX4_USABLE_IN_ARENA = 0x00020000,            // 17 usable in arena
        SPELL_ATTR_EX4_UNK18 = 0x00040000,            // 18
        SPELL_ATTR_EX4_UNK19 = 0x00080000,            // 19
        SPELL_ATTR_EX4_UNK20 = 0x00100000,            // 20 do not give "more powerful spell" error message
        SPELL_ATTR_EX4_UNK21 = 0x00200000,            // 21
        SPELL_ATTR_EX4_UNK22 = 0x00400000,            // 22
        SPELL_ATTR_EX4_UNK23 = 0x00800000,            // 23
        SPELL_ATTR_EX4_UNK24 = 0x01000000,            // 24
        SPELL_ATTR_EX4_UNK25 = 0x02000000,            // 25 pet scaling auras
        SPELL_ATTR_EX4_CAST_ONLY_IN_OUTLAND = 0x04000000,            // 26 Can only be used in Outland.
        SPELL_ATTR_EX4_UNK27 = 0x08000000,            // 27
        SPELL_ATTR_EX4_UNK28 = 0x10000000,            // 28
        SPELL_ATTR_EX4_UNK29 = 0x20000000,            // 29
        SPELL_ATTR_EX4_UNK30 = 0x40000000,            // 30
        SPELL_ATTR_EX4_UNK31 = 0x80000000,            // 31
    };

}
