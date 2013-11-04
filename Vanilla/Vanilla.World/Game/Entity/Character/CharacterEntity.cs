namespace Vanilla.World.Game.Entity.Character
{
    using System.Linq;

    using Vanilla.Core.DBC.Structs;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Network;

    public class CharacterEntity : Entity
    {
        public Character Character;

        public WorldSession Session;

        public CharacterEntity(Character databaseCharacter, WorldSession session)
        {
            Character = databaseCharacter;
            Session = session;
        }

        public override void Setup()
        {
            ObjectGUID = new ObjectGUID((ulong)Character.GUID);

            ChrRaces Race = Session.Core.DBC.GetDBC<ChrRaces>().SingleOrDefault(cr => cr.RaceID == Character.Race);
            ChrClasses Class = Session.Core.DBC.GetDBC<ChrClasses>().SingleOrDefault(cr => cr.ClassID == Character.Class);

            Info = new CharacterInfo(Character, ObjectGUID, Race, Class);

            PacketBuilder = new CharacterPacketBuilder(this);
            
            base.Setup();
        }
    }
}
