namespace Vanilla.World.Game.Entity.Character
{
    using Vanilla.Core.Constants.Character;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Game.Entity.Constants;

    public class CharacterInfo : EntityInfo
    {
        public CharacterInfo(Character databaseCharacter, ObjectGUID guid, ChrRaces race, ChrClasses chrClass) : base(guid)
        {
            X = databaseCharacter.PositionX;
            Y = databaseCharacter.PositionY;
            Z = databaseCharacter.PositionZ;
            Orientation = databaseCharacter.Orientation;

            GUID = guid.RawGUID;
            Type = 25;
            Scale = 1;
            Class = chrClass;
            ClassID = Class.ClassID;
            Gender = databaseCharacter.Gender;
            Power = (byte)Class.PowerType;

            Race = race;
            RaceID = race.RaceID;
            FactionTemplate = race.FactionID;
            DisplayID = NativeDisplayID = (int)(Gender == 0 ? race.ModelM : race.ModelF);

            Health = (int)databaseCharacter.Health;
            MaxHealth = 100;

            //Level = databaseCharacter.Level;
            XP = (int)databaseCharacter.XP;
            NextLevelXP = 400;
        }

        public ChrClasses Class { get; set; }

        public ChrRaces Race { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_LEVEL)]
        public int Level { get; set; }

        [UpdateField(EUnitFields.PLAYER_XP)]
        public int XP { get; set; }

        [UpdateField(EUnitFields.PLAYER_NEXT_LEVEL_XP)]
        public int NextLevelXP { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float Orientation { get; set; }

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
