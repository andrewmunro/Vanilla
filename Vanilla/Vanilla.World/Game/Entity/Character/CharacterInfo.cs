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
    }
}
