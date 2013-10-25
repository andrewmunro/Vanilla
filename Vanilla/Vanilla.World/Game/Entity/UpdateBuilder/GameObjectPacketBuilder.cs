namespace Vanilla.World.Game.Entity.UpdateBuilder
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

/*            writer.WritePackedUInt64(entity.ObjectGUID.RawGUID);

            writer.Write((byte)TypeID.TYPEID_GAMEOBJECT);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_TRANSPORT | ObjectUpdateFlag.UPDATEFLAG_ALL
                                           | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION;

            writer.Write((byte)updateFlags);

            // Position
            writer.Write((float)entity.X);
            writer.Write((float)entity.Y);
            writer.Write((float)entity.Z);

            writer.Write((float)entity.R); // R

            writer.Write((uint)0x1); // Unkown... time?
            writer.Write((uint)0); // Unkown... time?

            entity.WriteUpdateFields(this.Writer);*/

            return (writer.BaseStream as MemoryStream).ToArray();
        }
    }
}
