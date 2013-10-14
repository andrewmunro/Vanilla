﻿using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World.Update
{
    #region

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Vanilla.Core.Extensions;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Database.Models;
    using Vanilla.World.Game.Constants.Game.Update;
    using Vanilla.World.Game.Entitys;
    using Vanilla.World.Tools.Shared;
    using Character.Database.Models;

    #endregion

    public class PSUpdateObject : WorldPacket
    {
        #region Constructors and Destructors

        public PSUpdateObject(List<byte[]> blocks, int hasTansport = 0)
            : base(WorldOpcodes.SMSG_UPDATE_OBJECT)
        {
            this.Write((uint)blocks.Count());
            this.Write((byte)hasTansport); // Has transport

            // Write each block
            blocks.ForEach(b => Write(b));
        }

        public PSUpdateObject(List<UpdateBlock> blocks, int hasTansport = 0)
            : base(WorldOpcodes.SMSG_UPDATE_OBJECT)
        {
            this.Write((uint)blocks.Count());
            this.Write((byte)hasTansport); // Has transport

            // Write each block
            blocks.ForEach(block => Write(block.Data));
        }

        #endregion

        /* Needs moving */
        #region Public Methods and Operators

        public static PSUpdateObject BuildCreateUpdateBlock(ObjectEntity entity)
        {
            var writer = new BinaryWriter(new MemoryStream());

            var updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT;
            var updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL;

            if (updateFlags.HasFlag(ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION))
            {
                if (entity is PlayerEntity)
                {
                    updateType = ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2;
                }
            }

            writer.Write((byte)updateType);
            writer.WriteBytes(GenerateGuidBytes(entity.ObjectGUID.RawGUID));
            writer.Write((byte)entity.TypeID);

            // Movement
            var moveFlags = MovementFlags.MOVEFLAG_NONE;

            writer.Write((byte)updateFlags);

            if (updateFlags.HasFlag(ObjectUpdateFlag.UPDATEFLAG_LIVING))
            {
                writer.Write((uint)MovementFlags.MOVEFLAG_NONE);
                writer.Write((uint)Environment.TickCount); // Time
            }

            if (updateFlags.HasFlag(ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION))
            {
                // writer.Write((float)entity.X);
                // writer.Write((float)entity.Y);
                // writer.Write((float)entity.Z);
                writer.Write((float)0); // R
            }

            if (updateFlags.HasFlag(ObjectUpdateFlag.UPDATEFLAG_LIVING))
            {
                writer.Write((float)0); // Random..

                if (moveFlags.HasFlag(MovementFlags.MOVEFLAG_FALLING))
                {
                    writer.Write((float)0);
                    writer.Write((float)1);
                    writer.Write((float)0);
                    writer.Write((float)0);
                }

                writer.Write(2.5f); // MOVE_WALK
                writer.Write((float)7); // MOVE_RUN
                writer.Write(4.5f); // MOVE_RUN_BACK
                writer.Write(4.72f); // MOVE_SWIM
                writer.Write(2.5f); // MOVE_SWIM_BACK
                writer.Write(3.14f); // MOVE_TURN_RATE

                if (entity is UnitEntity)
                {
                    byte posCount = 0;
                    if (moveFlags.HasFlag(MovementFlags.MOVEFLAG_ASCENDING))
                    {
                        writer.Write(0x0);
                        writer.Write(0x659);
                        writer.Write(0xB7B);
                        writer.Write(0xFDA0B4);
                        writer.Write((int)posCount);

                        for (int i = 0; i < posCount + 1; i++)
                        {
                            writer.Write((float)0);
                            writer.Write((float)0);
                            writer.Write((float)0);
                        }
                    }
                }
            }

            if (updateFlags.HasFlag(ObjectUpdateFlag.UPDATEFLAG_ALL))
            {
                writer.Write(0x1);
            }

            if (updateFlags.HasFlag(ObjectUpdateFlag.UPDATEFLAG_TRANSPORT))
            {
                writer.Write((float)0);
            }

            // End Movement
            entity.WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }

        public static PSUpdateObject CreateCharacterUpdate(Character character)
        {
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

            byte[] guidBytes = GenerateGuidBytes((ulong)character.GUID);
            WriteBytes(writer, guidBytes, guidBytes.Length);

            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION
                                           | ObjectUpdateFlag.UPDATEFLAG_LIVING;

            writer.Write((byte)updateFlags);

            writer.Write((uint)MovementFlags.MOVEFLAG_NONE);
            writer.Write((uint)Environment.TickCount); // Time?

            // Position
            writer.Write(character.PositionX);
            writer.Write(character.PositionY);
            writer.Write(character.PositionZ);
            writer.Write(character.Orientation); // R

            // Movement speeds
            writer.Write((float)0); // ????

            writer.Write(2.5f); // MOVE_WALK
            writer.Write((float)7); // MOVE_RUN
            writer.Write(4.5f); // MOVE_RUN_BACK
            writer.Write(4.72f * 20); // MOVE_SWIM
            writer.Write(2.5f); // MOVE_SWIM_BACK
            writer.Write(3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            var a = new PlayerEntity(character);
            a.GUID = (uint)character.GUID;

            a.WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }

        public static PSUpdateObject CreateGameObject(
            float x, 
            float y, 
            float z, 
            GameObject gameObject, 
            GameObjectTemplate template)
        {
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

            var entity = new GOEntity(gameObject, template);

            byte[] guidBytes = GenerateGuidBytes(entity.ObjectGUID.RawGUID);

            for (int i = 0; i < guidBytes.Length; i++)
            {
                writer.Write(guidBytes[i]);
            }

            // BinaryReader reader = new BinaryReader(new MemoryStream(guidBytes));
            // ulong lol = ReadPackedGuid(reader);

            /*
            byte[] Guid = Utils.HexToByteArray("C7 E8 AB 02 C0 1F");
            BinaryReader reader = new BinaryReader(new MemoryStream(Guid));
            ulong lol = ReadPackedGuid(reader);

            Console.WriteLine("s");
             */
            /*
            HighGUID a = (HighGUID)((lol >> 48) & 0x0000FFFF);
            TypeID ID = (TypeID)((lol >> 24) & (ulong)0x0000000000FFFFFF);

            uint meh = (uint)(lol & (ulong)0x0000000000FFFFFF); // Counter?

            byte[] guidByteas = GenerateGuidBytes((ulong)lol);
            

            for (int i = 0; i < Guid.Length; i++)
            {
                writer.Write(Guid[i]);
            }
           */
            // Console.WriteLine("----> " + BitConverter.ToUInt32(Guid, 0));
            writer.Write((byte)TypeID.TYPEID_GAMEOBJECT);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_TRANSPORT | ObjectUpdateFlag.UPDATEFLAG_ALL
                                           | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION;

            writer.Write((byte)updateFlags);

            // Position
            writer.Write(x);
            writer.Write(y);
            writer.Write(z);

            writer.Write((float)0); // R

            writer.Write((uint)0x1); // Unkown... time?
            writer.Write((uint)0); // Unkown... time?

            entity.WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() }, 1);
        }

        public static PSUpdateObject CreateOutOfRangeUpdate(ObjectEntity entity)
        {
            var despawnEntity = new List<ObjectEntity>();
            despawnEntity.Add(entity);

            return CreateOutOfRangeUpdate(despawnEntity);
        }

        public static PSUpdateObject CreateOutOfRangeUpdate(List<ObjectEntity> entitys)
        {
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_OUT_OF_RANGE_OBJECTS);

            writer.Write((uint)entitys.Count);

            foreach (ObjectEntity entity in entitys)
            {
                writer.WritePackedUInt64(entity.ObjectGUID.RawGUID);

                // WriteBytes(writer, guidBytes, guidBytes.Length);
            }

            // byte[] guidBytes = GenerateGuidBytes((ulong)character.GUID);
            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }

        public static PSUpdateObject CreateOwnCharacterUpdate(Character character, out PlayerEntity entity)
        {
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

            // byte[] guidBytes = GenerateGuidBytes((ulong)character.GUID);
            // WriteBytes(writer, guidBytes, guidBytes.Length);
            writer.WritePackedUInt64((ulong)character.GUID);

            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION
                                           | ObjectUpdateFlag.UPDATEFLAG_LIVING | ObjectUpdateFlag.UPDATEFLAG_SELF;

            writer.Write((byte)updateFlags);

            writer.Write((uint)MovementFlags.MOVEFLAG_NONE);

            writer.Write((uint)Environment.TickCount);

            writer.Write(character.PositionX);
            writer.Write(character.PositionY);
            writer.Write(character.PositionZ);
            writer.Write(character.Orientation); // R

            // Movement speeds
            writer.Write((float)0); // ????

            writer.Write(2.5f); // MOVE_WALK
            writer.Write((float)7 * 3); // MOVE_RUN
            writer.Write(4.5f); // MOVE_RUN_BACK
            writer.Write(4.72f); // MOVE_SWIM
            writer.Write(2.5f); // MOVE_SWIM_BACK
            writer.Write(3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            entity = new PlayerEntity(character);
            entity.ObjectGUID = new ObjectGUID((ulong)character.GUID);

            entity.WriteUpdateFields(writer);

            var memoryStream = writer.BaseStream as MemoryStream;
            if (memoryStream != null)
            {
                return new PSUpdateObject(new List<byte[]> { memoryStream.ToArray() });
            }
            throw new Exception();
        }

        public static PSUpdateObject CreateUnitUpdate(PlayerEntity character)
        {
            var entity = new UnitEntity();
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
            writer.Write(character.X);
            writer.Write(character.Y);
            writer.Write(character.Z);
            writer.Write((float)0); // R

            // Movement speeds
            writer.Write((float)0); // ????

            writer.Write(2.5f); // MOVE_WALK
            writer.Write((float)7); // MOVE_RUN
            writer.Write(4.5f); // MOVE_RUN_BACK
            writer.Write(4.72f * 20); // MOVE_SWIM
            writer.Write(2.5f); // MOVE_SWIM_BACK
            writer.Write(3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            // entity.GUID = 1141440694;
            entity.Scale = 1;
            entity.WriteUpdateFields(writer);

            Console.WriteLine(" ");
            Log.Print(LogType.Debug, BitConverter.ToString((writer.BaseStream as MemoryStream).ToArray()));
            Console.WriteLine(" ");
            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }

        public static PSUpdateObject CreateUnitUpdate(UnitEntity entity)
        {
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
            writer.Write(entity.X);
            writer.Write(entity.Y);
            writer.Write(entity.Z);
            writer.Write((float)0); // R

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
            entity.Scale = 1;
            entity.WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }

        public static byte[] GenerateGuidBytes(ulong guid)
        {
            var packedGuid = new byte[9];
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

            var clippedArray = new byte[length];
            Array.Copy(packedGuid, clippedArray, length);

            return clippedArray;
        }

        public static ulong ReadPackedGuid(BinaryReader reader)
        {
            byte mask = reader.ReadByte();

            if (mask == 0)
            {
                return 0;
            }

            ulong res = 0;

            int i = 0;
            while (i < 8)
            {
                if ((mask & 1 << i) != 0)
                {
                    res += (ulong)reader.ReadByte() << (i * 8);
                }

                i++;
            }

            return res;
        }

        public static PSUpdateObject UpdateValues(ObjectEntity entity)
        {
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_VALUES);

            byte[] guidBytes = GenerateGuidBytes(entity.ObjectGUID.RawGUID);
            WriteBytes(writer, guidBytes, guidBytes.Length);

            // entity.SetUpdateField<float>((int)EObjectFields.OBJECT_FIELD_SCALE_X, (float)20f);
            // entity.SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION, (float)1f);
            // entity.SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_DISPLAYID, (uint)10);
            entity.WriteUpdateFields(writer);

            return new PSUpdateObject(
                new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() }, 
                (entity is PlayerEntity) ? 0 : 1);
        }

        public static void WriteBytes(BinaryWriter writer, byte[] data, int count = 0)
        {
            if (count == 0)
            {
                writer.Write(data);
            }
            else
            {
                writer.Write(data, 0, count);
            }
        }

        #endregion
    }
}