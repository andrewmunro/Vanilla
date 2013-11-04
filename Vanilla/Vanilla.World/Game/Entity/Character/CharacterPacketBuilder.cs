namespace Vanilla.World.Game.Entity.Character
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Vanilla.Core.Extensions;
    using Vanilla.World.Components.Update.Packets.Outgoing;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Update.Constants;

    public class CharacterPacketBuilder : EntityPacketBuilder
    {
        private CharacterEntity entity;

        public override int DataLength { get { return (int)EUnitFields.PLAYER_END - 0x4; }}

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
            foreach (UpdateFieldEntry entry in entity.Info.CreationUpdateFieldEntries)
            {
                byte key = entry.UpdateField;
                string name = entry.PropertyInfo.PropertyType.Name;
                var value = entry.PropertyInfo.GetValue(entity.Info);

                if (entry.Index == -1)
                {
                    if (name == "Int32") SetUpdateField<uint>((int)key, Convert.ToUInt32(value));
                    if (name == "Byte") SetUpdateField<byte>((int)key, Convert.ToByte(value));
                    if (name == "UInt64") SetUpdateField<ulong>((int)key, Convert.ToUInt64(value));
                    if (name == "Single") SetUpdateField<float>((int)key, Convert.ToSingle(value));
                }
                else
                {
                    if (name == "Byte") SetUpdateField<byte>((int)key, Convert.ToByte(value), (byte)entry.Index);
                }
            }
           


            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, (byte)0, 0); // Stand State?
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, 0xEE, 1); //  if (getPowerType() == POWER_RAGE || getPowerType() == POWER_MANA)
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, 0, 2); // ShapeshiftForm?
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, /* (byte)UnitBytes1_Flags.UNIT_BYTE1_FLAG_ALL */ 0, 3); // StandMiscFlags
            SetUpdateField<int>((int)EUnitFields.PLAYER_BYTES, 17235975);
            SetUpdateField<int>((int)EUnitFields.PLAYER_BYTES_2, 16777218);



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
            writer.Write((UInt32)55675); // Time?

            // Position
            writer.Write((float)-2917.580078125);
            writer.Write((float)-257.980010986328);
            writer.Write((float)52.9967994689941);
            writer.Write((float)0); // R

            // Movement speeds
            writer.Write((float)0);     // ????

            writer.Write((float)2.5f);  // MOVE_WALK
            writer.Write((float)7);     // MOVE_RUN
            writer.Write((float)4.5f);  // MOVE_RUN_BACK
            writer.Write((float)4.72f); // MOVE_SWIM
            writer.Write((float)2.5f);  // MOVE_SWIM_BACK
            writer.Write((float)3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]>() { (writer.BaseStream as MemoryStream).ToArray() });
        }


    }
}
