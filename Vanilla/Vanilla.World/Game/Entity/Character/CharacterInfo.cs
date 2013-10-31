namespace Vanilla.World.Game.Entity.Character
{
    using Vanilla.Core.Constants.Character;
    using Vanilla.Database.Character.Models;

    public class CharacterInfo : EntityInfo
    {
        public CharacterInfo(Character databaseCharacter, ObjectGUID guid) : base(guid)
        {
            X = databaseCharacter.PositionX;
            Y = databaseCharacter.PositionY;
            Z = databaseCharacter.PositionZ;
            Orientation = databaseCharacter.Orientation;

            GUID = (uint)1;
            Type = 25;

            Scale = 1;
            FactionTemplate = 1;
            Bytes1Race = (byte)RaceID.Dwarf;
            Bytes1Class = (byte)ClassID.Warrior;
            Bytes1Gender = (byte)Gender.Male;
            Bytes1Power = 0;

            DisplayID = 59;
            NativeDisplayID = 59;

            Health = 100;
            MaxHealth = 100;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float Orientation { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE)]
        public int FactionTemplate { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_0, true, 0)]
        public byte Bytes1Race { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_0, true, 1)]
        public byte Bytes1Class { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_0, true, 2)]
        public byte Bytes1Gender { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_0, true, 3)]
        public byte Bytes1Power { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_DISPLAYID)]
        public int DisplayID { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_NATIVEDISPLAYID)]
        public int NativeDisplayID { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_HEALTH)]
        public int Health { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_MAXHEALTH)]
        public int MaxHealth { get; set; }
    }
}
