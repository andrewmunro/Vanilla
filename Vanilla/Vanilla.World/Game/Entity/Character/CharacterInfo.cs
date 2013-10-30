namespace Vanilla.World.Game.Entity.Character
{
    using Vanilla.Database.Character.Models;

    public class CharacterInfo : EntityInfo
    {
        public CharacterInfo(Character databaseCharacter, ObjectGUID guid) : base(guid)
        {
            X = databaseCharacter.PositionX;
            Y = databaseCharacter.PositionY;
            Z = databaseCharacter.PositionZ;
            Orientation = databaseCharacter.Orientation;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float Orientation { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_POWER1)]
        public int Power1 { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE)]
        public int FactionID { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_MAXPOWER1)]
        public int MaxPower1 { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_MAXPOWER2)]
        public int MaxPower2 { get; set; }


    }
}
