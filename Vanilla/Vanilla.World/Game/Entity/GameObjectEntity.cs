namespace Vanilla.World.Game.Entity
{
    using Vanilla.World.Game.Entity.UpdateBuilder;

    public class GameObjectEntity : Entity
    {
        public GameObjectEntity()
        {
            this.Builder = new GameObjectPacketBuilder(this);
        }
    }
}
