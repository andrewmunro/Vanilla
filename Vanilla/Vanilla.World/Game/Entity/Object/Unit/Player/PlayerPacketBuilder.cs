namespace Vanilla.World.Game.Entity.Object.Unit.Player
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.Core.Extensions;
    using Vanilla.World.Components.Update.Packets.Outgoing;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object.Unit.Creature;
    using Vanilla.World.Game.Update.Constants;

    public class PlayerPacketBuilder : EntityPacketBuilder
    {
        private PlayerEntity entity;

        public override int DataLength { get { return (int)EUnitFields.PLAYER_END - 0x4; }}

        public PlayerPacketBuilder(PlayerEntity entity)
        {
            this.entity = entity;
        }

        protected override byte[] BuildUpdatePacket()
        {
            throw new System.NotImplementedException();
        }

        protected override byte[] BuildCreatePacket()
        {
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

            byte[] guidBytes = GenerateGuidBytes(this.entity.ObjectGUID.RawGUID);
            WriteBytes(writer, guidBytes, guidBytes.Length);

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

            writer.Write(2.5f); // MOVE_WALK
            writer.Write((float)7); // MOVE_RUN
            writer.Write(4.5f); // MOVE_RUN_BACK
            writer.Write(4.72f * 20); // MOVE_SWIM
            writer.Write(2.5f); // MOVE_SWIM_BACK
            writer.Write(3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            this.WriteUpdateFields(writer);

            return (writer.BaseStream as MemoryStream).ToArray();
        }

        /* Needs moving */
        public static byte[] GenerateGuidBytes(ulong guid)
        {
            byte[] packedGuid = new byte[9];
            byte length = 1;

            for (byte i = 0; guid != 0; i++)
            {
                if ((guid & 0xFF) != 0)
                {
                    packedGuid[0] |= (byte)(1 << i);
                    packedGuid[length] = (byte)(guid & 0xFF);
                    ++length;
                }

                guid >>= 8;
            }

            byte[] clippedArray = new byte[length];
            Array.Copy(packedGuid, clippedArray, length);

            return clippedArray;
        }

        /* Needs moving */
        public static void WriteBytes(BinaryWriter writer, byte[] data, int count = 0)
        {
            if (count == 0)
                writer.Write(data);
            else
                writer.Write(data, 0, count);
        }

        public PSUpdateObject BuildOwnCharacterPacket()
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

            writer.Write((float)2.5f);  // MOVE_WALK
            writer.Write((float)7);     // MOVE_RUN
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
