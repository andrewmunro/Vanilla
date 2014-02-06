namespace Vanilla.World.Game.Entity.Object.Player
{
    using System.Linq;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Components.ActionBar;
    using Vanilla.World.Components.Misc.Packets.Outgoing;
    using Vanilla.World.Components.Spell;
    using Vanilla.World.Network;
    using Vanilla.World.Game.Entity.Object.Unit;

    public class PlayerEntity : UnitEntity<PlayerInfo, PlayerPacketBuilder>
    {
        public Character Character;

        public WorldSession Session;

        public SpellCollection SpellCollection;

        public ActionButtonCollection ActionButtonCollection;

        public string Name { get { return Character.Name; } }

        public UnitEntity<UnitInfo, EntityPacketBuilder> Target;

        public PlayerEntity(ObjectGUID objectGUID, Character databaseCharacter, WorldSession session) : base(objectGUID)
        {
            this.Character = databaseCharacter;
            this.Session = session;
            this.SpellCollection = new SpellCollection(this);
            this.ActionButtonCollection = new ActionButtonCollection(this);
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

        public void TeleportTo(long mapID, float x, float y, float z, float r = 0)
        {
            if (Location.MapID != mapID)
            {
                Session.SendPacket(new PSTransferPending((int)mapID));
            }

            Character.Map = mapID;
            Character.PositionX = x;
            Character.PositionY = y;
            Character.PositionZ = z;
            Character.Orientation = r;
            Session.Core.CharacterDatabase.SaveChanges();

            Session.SendPacket(new PSNewWorld((int)mapID, x, y, z, r));
        }
    }
}
