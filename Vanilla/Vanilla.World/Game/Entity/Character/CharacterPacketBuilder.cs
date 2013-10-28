namespace Vanilla.World.Game.Entity.Character
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.Core.Extensions;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.UpdateBuilder;
    using Vanilla.World.Game.Update;
    using Vanilla.World.Game.Update.Constants;

    public class CharacterPacketBuilder : EntityPacketBuilder
    {
        private CharacterEntity entity;

        public CharacterPacketBuilder(CharacterEntity entity)
        {
            this.entity = entity;
        }

        protected override byte[] BuildUpdatePacket()
        {
            throw new System.NotImplementedException();
        }

        protected override byte[] BuildCreatePacket()
        {
            throw new System.NotImplementedException();
        }

        public byte[] BuildOwnCharacterPacket()
        {
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

            writer.WritePackedUInt64((ulong)entity.Info.GUID);

            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION
                                           | ObjectUpdateFlag.UPDATEFLAG_LIVING | ObjectUpdateFlag.UPDATEFLAG_SELF;

            writer.Write((byte)updateFlags);

            writer.Write((uint)MovementFlags.MOVEFLAG_NONE);

            writer.Write((uint)Environment.TickCount);

            writer.Write(entity.Info.X);
            writer.Write(entity.Info.Y);
            writer.Write(entity.Info.Z);
            writer.Write(entity.Info.Orientation); // R

            // Movement speeds
            writer.Write((float)0); // ????

            writer.Write(2.5f); // MOVE_WALK
            writer.Write((float)7 * 3); // MOVE_RUN
            writer.Write(4.5f); // MOVE_RUN_BACK
            writer.Write(4.72f); // MOVE_SWIM
            writer.Write(2.5f); // MOVE_SWIM_BACK
            writer.Write(3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            WriteCreationFields(writer);

            return (writer.BaseStream as MemoryStream).ToArray();
        }


    }
}
