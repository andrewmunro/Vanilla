namespace Vanilla.World.Game.Entity.Object.Unit
{
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Tools;

    public abstract class UnitInfo : ObjectInfo
    {
        public UnitInfo(ObjectGUID guid) : base(guid)
        {
            Health = 1;
            MaxHealth = 100;
            DisplayID = NativeDisplayID = 1;

            StandState = 0;
            StandStateFlags = 0;

            Type |= (int)TypeMask.TYPEMASK_UNIT;
        }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_1, true, 1)]
        public byte StandState { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_1, true, 3)]
        public byte StandStateFlags { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_LEVEL)]
        public int Level { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_HEALTH)]
        public int Health { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_MAXHEALTH)]
        public int MaxHealth { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_DISPLAYID)]
        public int DisplayID { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_NATIVEDISPLAYID)]
        public int NativeDisplayID { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_TARGET)]
        public ulong Target { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE)]
        public uint FactionTemplate { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_0, true, 0)]
        public byte RaceID { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_0, true, 1)]
        public byte ClassID { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_0, true, 2)]
        public byte Gender { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_0, true, 3)]
        public byte Power { get; set; }
    }
}
