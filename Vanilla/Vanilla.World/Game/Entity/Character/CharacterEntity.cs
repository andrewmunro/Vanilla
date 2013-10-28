namespace Vanilla.World.Game.Entity.Character
{
    using Vanilla.Database.Character.Models;

    public class CharacterEntity : Entity
    {
        public Character Character;

        public CharacterEntity(Character databaseCharacter) : base()
        {
            Character = databaseCharacter;
        }

        public override void Setup()
        {
            ObjectGUID = new ObjectGUID((ulong)Character.GUID);
            Info = new CharacterInfo(Character, ObjectGUID);

            PacketBuilder = new CharacterPacketBuilder(this);

            base.Setup();
        }

    }
}
