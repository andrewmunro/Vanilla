namespace Vanilla.World.Game.Entity.GameObject
{
    using Vanilla.World.Game.Entity.Constants;

    public class GameObjectEntity : Entity
    {
        public GameObjectEntity()
        {
            //ObjectGUID = new ObjectGUID(ulong);
            Info = new GameObjectInfo(ObjectGUID);
            PacketBuilder = new GameObjectPacketBuilder(this);
        }
    }
}
