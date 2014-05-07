namespace Vanilla.World.Game.Entity.Object.Player
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.Core.Extensions;
    using Vanilla.World.Components.Update.Packets.Outgoing;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Update.Constants;

    public class PlayerPacketBuilder : EntityPacketBuilder
    {
        private readonly PlayerEntity entity;

        public override int DataLength { get { return (int)EUnitFields.PLAYER_END - 0x4; }}

        public PlayerPacketBuilder(PlayerEntity entity)
        {
            this.entity = entity;
        }

        protected override byte[] BuildUpdatePacket()
        {
            foreach (var creationUpdateFieldEntry in entity.Info.CreationUpdateFieldEntries)
            {
                UpdateQueue.Enqueue(creationUpdateFieldEntry);
            }

            this.SetInfoFields(entity.Info);
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_VALUES);
            writer.WritePackedUInt64(entity.ObjectGUID.RawGUID);
            this.WriteUpdateFields(writer);
            return (writer.BaseStream as MemoryStream).ToArray();
        }

        protected override byte[] BuildCreatePacket()
        {
            foreach (var creationUpdateFieldEntry in entity.Info.CreationUpdateFieldEntries)
            {
                UpdateQueue.Enqueue(creationUpdateFieldEntry);
            }

            SetInfoFields(entity.Info);

            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

            writer.WritePackedUInt64(this.entity.ObjectGUID.RawGUID);

            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION
                                           | ObjectUpdateFlag.UPDATEFLAG_LIVING;

            writer.Write((byte)updateFlags);

            writer.Write((uint)MovementFlags.MOVEFLAG_NONE);
            writer.Write((uint)Environment.TickCount); // Time?

            // Position
            writer.Write(entity.Location.X);
            writer.Write(entity.Location.Y);
            writer.Write(entity.Location.Z);
            writer.Write(entity.Location.Orientation); // R

            // Movement speeds
            writer.Write((float)0); // ????

            writer.Write(entity.Info.WalkSpeed); // MOVE_WALK
            writer.Write((float)7); // MOVE_RUN
            writer.Write(4.5f); // MOVE_RUN_BACK
            writer.Write(4.72f * 20); // MOVE_SWIM
            writer.Write(2.5f); // MOVE_SWIM_BACK
            writer.Write(3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            this.WriteUpdateFields(writer);

            return (writer.BaseStream as MemoryStream).ToArray();
        }

        public PSUpdateObject BuildOwnCharacterPacket()
        {
            foreach (var creationUpdateFieldEntry in entity.Info.CreationUpdateFieldEntries)
            {
                UpdateQueue.Enqueue(creationUpdateFieldEntry);
            }

            SetInfoFields(entity.Info);

            BinaryWriter writer = new BinaryWriter(new MemoryStream());

            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);
            writer.WritePackedUInt64(this.entity.ObjectGUID.RawGUID);
            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL |
                                        ObjectUpdateFlag.UPDATEFLAG_SELF |
                                      ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION |
                                      ObjectUpdateFlag.UPDATEFLAG_LIVING;

            writer.Write((byte)updateFlags);

            writer.Write((UInt32)MovementFlags.MOVEFLAG_NONE);
            writer.Write((UInt32)Environment.TickCount); // Time?

            // Position
            writer.Write((float)entity.Location.X);
            writer.Write((float)entity.Location.Y);
            writer.Write((float)entity.Location.Z);
            writer.Write((float)entity.Location.Orientation); // R

            // Movement speeds
            writer.Write((float)0);     // ????

            writer.Write((float)entity.Info.WalkSpeed);  // MOVE_WALK
            writer.Write((float)20f);     // MOVE_RUN
            writer.Write((float)4.5f);  // MOVE_RUN_BACK
            writer.Write((float)4.72f); // MOVE_SWIM
            writer.Write((float)2.5f);  // MOVE_SWIM_BACK
            writer.Write((float)3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            this.WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]>() { (writer.BaseStream as MemoryStream).ToArray() });
        }
    }
}
