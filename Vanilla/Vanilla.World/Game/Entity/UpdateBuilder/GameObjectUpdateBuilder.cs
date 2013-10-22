namespace Vanilla.World.Game.Entity.UpdateBuilder
{
    using System.IO;

    using Vanilla.Core.Extensions;

    public class GameObjectUpdateBuilder : IEntityUpdatePacketBuilder
    {
        private GameObjectEntity entity;

        public GameObjectUpdateBuilder(GameObjectEntity entity)
        {
            this.entity = entity;
        }

        private byte[] updatePacket { get; set; }

        private byte[] createPacket { get; set; }

        public byte[] UpdatePacket()
        {
            if (updatePacket != null) return updatePacket;

            var writer = new BinaryWriter(new MemoryStream());

            return updatePacket = (writer.BaseStream as MemoryStream).ToArray();
        }

        public byte[] CreatePacket()
        {
            if (createPacket != null) return createPacket;

            var writer = new BinaryWriter(new MemoryStream());

            writer.WritePackedUInt64(entity.ObjectGUID.RawGUID);

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

            entity.WriteUpdateFields(this.Writer);

            return createPacket = (writer.BaseStream as MemoryStream).ToArray();
        }

        public void resetCreatePacket()
        {
            createPacket = null;
        }

        public void resetUpdatePacket()
        {
            updatePacket = null;
        }
    }
}
