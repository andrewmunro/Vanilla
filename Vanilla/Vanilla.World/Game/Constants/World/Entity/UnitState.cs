namespace Vanilla.World.Game.Constants.Game.World.Entity
{
    enum UnitState
    {
        // persistent state (applied by aura/etc until expire)
        UNIT_STAT_MELEE_ATTACKING = 0x00000001,                 // unit is melee attacking someone Unit::Attack
        UNIT_STAT_ATTACK_PLAYER = 0x00000002,                 // unit attack player or player's controlled unit and have contested pvpv timer setup, until timer expire, combat end and etc
        UNIT_STAT_DIED = 0x00000004,                 // Unit::SetFeignDeath
        UNIT_STAT_STUNNED = 0x00000008,                 // Aura::HandleAuraModStun
        UNIT_STAT_ROOT = 0x00000010,                 // Aura::HandleAuraModRoot
        UNIT_STAT_ISOLATED = 0x00000020,                 // area auras do not affect other players, Aura::HandleAuraModSchoolImmunity
        UNIT_STAT_CONTROLLED = 0x00000040,                 // Aura::HandleAuraModPossess

        // persistent movement generator state (all time while movement generator applied to unit (independent from top state of movegen)
        UNIT_STAT_TAXI_FLIGHT = 0x00000080,                 // player is in flight mode (in fact interrupted at far teleport until next map telport landing)
        UNIT_STAT_DISTRACTED = 0x00000100,                 // DistractedMovementGenerator active

        // persistent movement generator state with non-persistent mirror states for stop support
        // (can be removed temporary by stop command or another movement generator apply)
        // not use _MOVE versions for generic movegen state, it can be removed temporary for unit stop and etc
        UNIT_STAT_CONFUSED = 0x00000200,                 // ConfusedMovementGenerator active/onstack
        UNIT_STAT_CONFUSED_MOVE = 0x00000400,
        UNIT_STAT_ROAMING = 0x00000800,                 // RandomMovementGenerator/PointMovementGenerator/WaypointMovementGenerator active (now always set)
        UNIT_STAT_ROAMING_MOVE = 0x00001000,
        UNIT_STAT_CHASE = 0x00002000,                 // ChaseMovementGenerator active
        UNIT_STAT_CHASE_MOVE = 0x00004000,
        UNIT_STAT_FOLLOW = 0x00008000,                 // FollowMovementGenerator active
        UNIT_STAT_FOLLOW_MOVE = 0x00010000,
        UNIT_STAT_FLEEING = 0x00020000,                 // FleeMovementGenerator/TimedFleeingMovementGenerator active/onstack
        UNIT_STAT_FLEEING_MOVE = 0x00040000,
        // More room for other MMGens

        // High-Level states (usually only with Creatures)
        UNIT_STAT_NO_COMBAT_MOVEMENT = 0x01000000,           // Combat Movement for MoveChase stopped
        UNIT_STAT_RUNNING = 0x02000000,           // SetRun for waypoints and such
        UNIT_STAT_WAYPOINT_PAUSED = 0x04000000,           // Waypoint-Movement paused genericly (ie by script)

        UNIT_STAT_IGNORE_PATHFINDING = 0x10000000,           // do not use pathfinding in any MovementGenerator

        // masks (only for check)

        // can't move currently
        UNIT_STAT_CAN_NOT_MOVE = UNIT_STAT_ROOT | UNIT_STAT_STUNNED | UNIT_STAT_DIED,

        // stay by different reasons
        UNIT_STAT_NOT_MOVE = UNIT_STAT_ROOT | UNIT_STAT_STUNNED | UNIT_STAT_DIED |
                                    UNIT_STAT_DISTRACTED,

        // stay or scripted movement for effect( = in player case you can't move by client command)
        UNIT_STAT_NO_FREE_MOVE = UNIT_STAT_ROOT | UNIT_STAT_STUNNED | UNIT_STAT_DIED |
                                    UNIT_STAT_TAXI_FLIGHT |
                                    UNIT_STAT_CONFUSED | UNIT_STAT_FLEEING,

        // not react at move in sight or other
        UNIT_STAT_CAN_NOT_REACT = UNIT_STAT_STUNNED | UNIT_STAT_DIED |
                                    UNIT_STAT_CONFUSED | UNIT_STAT_FLEEING,

        // AI disabled by some reason
        UNIT_STAT_LOST_CONTROL = UNIT_STAT_FLEEING | UNIT_STAT_CONTROLLED,

        // above 2 state cases
        UNIT_STAT_CAN_NOT_REACT_OR_LOST_CONTROL = UNIT_STAT_CAN_NOT_REACT | UNIT_STAT_LOST_CONTROL,

        // masks (for check or reset)

        // for real move using movegen check and stop (except unstoppable flight)
        UNIT_STAT_MOVING = UNIT_STAT_ROAMING_MOVE | UNIT_STAT_CHASE_MOVE | UNIT_STAT_FOLLOW_MOVE | UNIT_STAT_FLEEING_MOVE,

        UNIT_STAT_RUNNING_STATE = UNIT_STAT_CHASE_MOVE | UNIT_STAT_FLEEING_MOVE | UNIT_STAT_RUNNING,/*

        UNIT_STAT_ALL_STATE = 0xFFFFFFFF,
        UNIT_STAT_ALL_DYN_STATES = UNIT_STAT_ALL_STATE & ~(UNIT_STAT_NO_COMBAT_MOVEMENT | UNIT_STAT_RUNNING | UNIT_STAT_WAYPOINT_PAUSED | UNIT_STAT_IGNORE_PATHFINDING)*/
    }
}
