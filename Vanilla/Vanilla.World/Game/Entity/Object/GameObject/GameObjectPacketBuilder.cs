namespace Vanilla.World.Game.Entity.Object.GameObject
{
    using System.IO;

    public class GameObjectPacketBuilder : EntityPacketBuilder
    {
        private GameObjectEntity entity;

        public GameObjectPacketBuilder(GameObjectEntity entity)
        {
            this.entity = entity;
        }

        protected override byte[] BuildUpdatePacket()
        {
            var writer = new BinaryWriter(new MemoryStream());

            return (writer.BaseStream as MemoryStream).ToArray();
        }

        protected override byte[] BuildCreatePacket()
        {
            var writer = new BinaryWriter(new MemoryStream());

            return (writer.BaseStream as MemoryStream).ToArray();
        }
    }
}
