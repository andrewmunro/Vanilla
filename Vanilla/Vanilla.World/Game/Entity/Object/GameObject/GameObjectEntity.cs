namespace Vanilla.World.Game.Entity.Object.GameObject
{
    using Vanilla.Database.World.Models;

    public class GameObjectEntity : ObjectEntity<GameObjectInfo, GameObjectPacketBuilder>
    {
        public GameObject GameObject;

        public GameObjectEntity(ObjectGUID objectGUID, GameObject databaseGameObject) : base(objectGUID)
        {
            this.GameObject = databaseGameObject;
        }

        public override void Setup()
        {
            this.Info = new GameObjectInfo(this.ObjectGUID, this.GameObject);
            this.PacketBuilder = new GameObjectPacketBuilder(this);

            base.Setup();
        }
    }
}
