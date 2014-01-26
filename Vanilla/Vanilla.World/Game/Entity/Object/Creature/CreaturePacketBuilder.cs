namespace Vanilla.World.Game.Entity.Object.Creature
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.Core.Extensions;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Update.Constants;

    public class CreaturePacketBuilder : EntityPacketBuilder
    {
        private CreatureEntity entity;

        public override int DataLength { get { return (int)EUnitFields.PLAYER_END - 0x4; }}

        public CreaturePacketBuilder(CreatureEntity entity)
        {
            this.entity = entity;
        }

        protected override byte[] BuildUpdatePacket()
        {
            throw new System.NotImplementedException();
        }

        protected override byte[] BuildCreatePacket()
        {
            foreach (UpdateFieldEntry entry in this.entity.Info.CreationUpdateFieldEntries)
            {
                byte key = entry.UpdateField;
                string name = entry.PropertyInfo.PropertyType.Name;
                var value = entry.PropertyInfo.GetValue(this.entity.Info);

                if (entry.Index == -1)
                {
                    if (name == "Int32") this.SetUpdateField<uint>((int)key, Convert.ToUInt32(value));
                    if (name == "Byte") this.SetUpdateField<byte>((int)key, Convert.ToByte(value));
                    if (name == "UInt64") this.SetUpdateField<ulong>((int)key, Convert.ToUInt64(value));
                    if (name == "Single") this.SetUpdateField<float>((int)key, Convert.ToSingle(value));
                }
                else
                {
                    if (name == "Byte") this.SetUpdateField<byte>((int)key, Convert.ToByte(value), (byte)entry.Index);
                }
            }
            var writer = new BinaryWriter(new MemoryStream());

            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

            writer.WritePackedUInt64(entity.ObjectGUID.RawGUID);
            writer.Write((byte)TypeID.TYPEID_UNIT);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL | ObjectUpdateFlag.UPDATEFLAG_LIVING
                                           | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION;

            writer.Write((byte)updateFlags);
            writer.Write((UInt32)0x00000000); // MovementFlags

            writer.Write((UInt32)Environment.TickCount); // Time

            // 3 bytes ahead?

            // Position
            writer.Write(entity.Location.X);
            writer.Write(entity.Location.Y);
            writer.Write(entity.Location.Z);
            writer.Write(entity.Location.Orientation); // R

            // Movement speeds
            writer.Write((float)0); // ????

            writer.Write(2.5f); // MOVE_WALK
            writer.Write((float)7); // MOVE_RUN
            writer.Write(4.5f); // MOVE_RUN_BACK
            writer.Write(4.72f); // MOVE_SWIM
            writer.Write(2.5f); // MOVE_SWIM_BACK
            writer.Write(3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            // entity.GUID = 1141440694;
            this.WriteUpdateFields(writer);

            return (writer.BaseStream as MemoryStream).ToArray();
        
        }
    }
}
