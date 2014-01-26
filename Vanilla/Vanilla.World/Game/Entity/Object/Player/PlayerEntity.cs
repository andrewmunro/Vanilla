namespace Vanilla.World.Game.Entity.Object.Player
{
    using System.Linq;

    using Microsoft.Xna.Framework;

    using Vanilla.Core.DBC.Structs;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Network;
    using Vanilla.World.Game.Entity.Object.Unit;

    public class PlayerEntity : UnitEntity<PlayerInfo, PlayerPacketBuilder>
    {
        public Character Character;

        public WorldSession Session;

        public PlayerEntity(ObjectGUID objectGUID, Character databaseCharacter, WorldSession session) : base(objectGUID)
        {
            this.Character = databaseCharacter;
            this.Session = session;
        }

        public override void Setup()
        {
            ChrRaces Race = this.Session.Core.DBC.GetDBC<ChrRaces>().SingleOrDefault(cr => cr.RaceID == this.Character.Race);
            ChrClasses Class = this.Session.Core.DBC.GetDBC<ChrClasses>().SingleOrDefault(cr => cr.ClassID == this.Character.Class);

            this.Info = new PlayerInfo(this.ObjectGUID, this.Character, Race, Class);
            this.PacketBuilder = new PlayerPacketBuilder(this);

            Location.X = Character.PositionX;
            Location.Y = Character.PositionY;
            Location.Z = Character.PositionZ;
            Location.Orientation = Character.Orientation;
            Location.MapID = (int)Character.Map;

            base.Setup();
        }
    }
}
