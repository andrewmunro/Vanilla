namespace Vanilla.World.Game.Entity
{
    using Vanilla.World.Game.Entity.UpdateBuilder;

    public class GameObjectEntity : Entity
    {
        public GameObjectEntity()
        {
            updateBuilder = new GameObjectUpdateBuilder(this);
        }
    }
}
