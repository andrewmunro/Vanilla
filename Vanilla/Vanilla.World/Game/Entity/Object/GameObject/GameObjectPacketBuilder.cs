namespace Vanilla.World.Game.Entity.Object.GameObject
{
    using System.IO;

    using Vanilla.Core.Extensions;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Update.Constants;

    public class GameObjectPacketBuilder : EntityPacketBuilder
    {
        private readonly GameObjectEntity entity;

        public override int DataLength { get { return (int)EGameObjectFields.GAMEOBJECT_END; } }

        public GameObjectPacketBuilder(GameObjectEntity entity)
        {
            this.entity = entity;
        }

        protected override byte[] BuildUpdatePacket()
        {
            throw new System.NotImplementedException();
        }

        protected override byte[] BuildCreatePacket()
        {
            SetInfoFields(entity.Info);

            var writer = new BinaryWriter(new MemoryStream());

            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);
            writer.WritePackedUInt64(this.entity.ObjectGUID.RawGUID);
            writer.Write((byte)TypeID.TYPEID_GAMEOBJECT);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_TRANSPORT | ObjectUpdateFlag.UPDATEFLAG_ALL
                                           | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION;

            writer.Write((byte)updateFlags);

            // Position
            writer.Write(entity.Location.X);
            writer.Write(entity.Location.Y);
            writer.Write(entity.Location.Z);

            writer.Write(entity.Location.Orientation); // R

            writer.Write((uint)0x1); // Unkown... time?
            writer.Write((uint)0); // Unkown... time?

            WriteUpdateFields(writer);

            return (writer.BaseStream as MemoryStream).ToArray();
        }
    }
}
