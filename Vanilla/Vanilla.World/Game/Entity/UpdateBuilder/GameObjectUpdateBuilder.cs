namespace Vanilla.World.Game.Entity.UpdateBuilder
{
    using System.Collections.Generic;
    using System.IO;

    public class GameObjectUpdateBuilder : EntityUpdatePacketBuilder
    {
        private GameObjectEntity entity;

        public override Queue<UpdateField> UpdateQueue { get; set; }

        public GameObjectUpdateBuilder(GameObjectEntity entity)
        {
            this.entity = entity;
            UpdateQueue = new Queue<UpdateField>();
        }

        public override byte[] UpdatePacket()
        {
            var writer = new BinaryWriter(new MemoryStream());

            return (writer.BaseStream as MemoryStream).ToArray();
        }

        public override byte[] CreatePacket()
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
