using Vanilla.World.Database;

namespace Vanilla.World.Game.Entity.Object.GameObject
{

    public class GameObjectEntity : ObjectEntity<GameObjectInfo, GameObjectPacketBuilder>
    {
        public gameobject_template Template { get; set; }

        public gameobject GameObject;

        public GameObjectEntity(ObjectGUID objectGUID, gameobject databaseGameObject, gameobject_template template)
            : base(objectGUID)
        {
            this.Template = template;
            this.GameObject = databaseGameObject;
        }

        public override void Setup()
        {
            this.Info = new GameObjectInfo(this.ObjectGUID, this.GameObject, this.Template);
            this.PacketBuilder = new GameObjectPacketBuilder(this);

            Location.X = GameObject.position_x;
            Location.Y = GameObject.position_y;
            Location.Z = GameObject.position_z;
            Location.Orientation = GameObject.orientation;

            base.Setup();
        }
    }
}
