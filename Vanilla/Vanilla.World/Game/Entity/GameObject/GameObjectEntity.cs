namespace Vanilla.World.Game.Entity.GameObject
{
    public class GameObjectEntity : Entity
    {
        public GameObjectEntity()
        {
            Info = new GameObjectInfo();
            PacketBuilder = new GameObjectPacketBuilder(this);
        }
    }
}
