namespace Vanilla.World.Game.Entity.Object.GameObject
{
    using Vanilla.Database.World.Models;

    public class GameObjectEntity : ObjectEntity<GameObjectInfo, GameObjectPacketBuilder>
    {
        public GameObjectTemplate Template { get; set; }

        public GameObject GameObject;

        public GameObjectEntity(ObjectGUID objectGUID, GameObject databaseGameObject, GameObjectTemplate template) : base(objectGUID)
        {
            this.Template = template;
            this.GameObject = databaseGameObject;
        }

        public override void Setup()
        {
            this.Info = new GameObjectInfo(this.ObjectGUID, this.GameObject);
            this.PacketBuilder = new GameObjectPacketBuilder(this);

            Location.X = GameObject.PositionX;
            Location.Y = GameObject.PositionY;
            Location.Z = GameObject.PositionZ;
            Location.Orientation = GameObject.Orientation;

            base.Setup();
        }
    }
}
