using Vanilla.Character.Database;

namespace Vanilla.World.Game.Entity.Object.Player
{
    using System.Linq;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.World.Components.ActionBar;
    using Vanilla.World.Components.Misc.Packets.Outgoing;
    using Vanilla.World.Components.Spell;
    using Vanilla.World.Network;
    using Vanilla.World.Game.Entity.Object.Unit;

    public class PlayerEntity : UnitEntity<PlayerInfo, PlayerPacketBuilder>, IUnitEntity
    {
        public character Character;

        public WorldSession Session;

        public SpellCollection SpellCollection;

        public ActionButtonCollection ActionButtonCollection;

        public string Name { get { return Character.name; } }

        public IUnitEntity Target;

        public PlayerEntity(ObjectGUID objectGUID, character databaseCharacter, WorldSession session) : base(objectGUID)
        {
            this.Character = databaseCharacter;
            this.Session = session;
            this.SpellCollection = new SpellCollection(this);
            this.ActionButtonCollection = new ActionButtonCollection(this);
        }

        public override void Setup()
        {
            ChrRaces Race = this.Session.Core.DBC.GetDBC<ChrRaces>().SingleOrDefault(cr => cr.RaceID == this.Character.race);
            ChrClasses Class = this.Session.Core.DBC.GetDBC<ChrClasses>().SingleOrDefault(cr => cr.ClassID == this.Character.@class);

            this.Info = new PlayerInfo(this.ObjectGUID, this.Character, Race, Class);
            this.PacketBuilder = new PlayerPacketBuilder(this);

            Location.X = Character.position_x;
            Location.Y = Character.position_y;
            Location.Z = Character.position_z;
            Location.Orientation = Character.orientation;
            Location.MapID = (int)Character.map;

            base.Setup();
        }

        public void TeleportTo(long mapID, float x, float y, float z, float r = 0)
        {
            if (Location.MapID != mapID)
            {
                Session.SendPacket(new PSTransferPending((int)mapID));
            }

            Character.map = mapID;
            Character.position_x = x;
            Character.position_y = y;
            Character.position_z = z;
            Character.orientation = r;
            Session.Core.CharacterDatabase.SaveChanges();

            Session.SendPacket(new PSNewWorld((int)mapID, x, y, z, r));
        }
    }
}
