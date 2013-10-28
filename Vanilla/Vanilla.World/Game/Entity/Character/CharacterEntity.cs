namespace Vanilla.World.Game.Entity.Character
{
    using Vanilla.Database.Character.Models;

    public class CharacterEntity : Entity
    {
        public CharacterInfo Info;

        public CharacterEntity(Character databaseCharacter)
        {
            ObjectGUID = new ObjectGUID((ulong)databaseCharacter.GUID);
            Info = new CharacterInfo(databaseCharacter, ObjectGUID);
            PacketBuilder = new CharacterPacketBuilder(this);
        }
    }
}
