using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Entitys;
using Milkshake.Network;
using Milkshake.Tools.Database;
using System.IO;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.Update;
using Milkshake.Tools;
using Milkshake.Net;

namespace Milkshake.Communication.Outgoing.World.Update
{
	public class PSUpdateObject : ServerPacket
	{
		public PSUpdateObject(List<byte[]> blocks, int hasTansport = 0) : base(Opcodes.SMSG_UPDATE_OBJECT)
		{
			Write((uint)blocks.Count());
			Write((byte)hasTansport); // Has transport

			// Write each block
			blocks.ForEach(b => Write(b));
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

		public static PSUpdateObject CreateOwnCharacterUpdate(Character character, out PlayerEntity entity)
		{
			BinaryWriter writer = new BinaryWriter(new MemoryStream());
			writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

			byte[] guidBytes = GenerateGuidBytes((ulong)character.GUID);
			WriteBytes(writer, guidBytes, guidBytes.Length);
			
			
			writer.Write((byte)TypeID.TYPEID_PLAYER);

			ObjectFlags updateFlags = ObjectFlags.UPDATEFLAG_ALL |
									  ObjectFlags.UPDATEFLAG_HAS_POSITION |
									  ObjectFlags.UPDATEFLAG_LIVING |
									  ObjectFlags.UPDATEFLAG_SELF;

			writer.Write((byte)updateFlags);

			writer.Write((UInt32)MovementFlags.MOVEFLAG_NONE);
			writer.Write((UInt32)Environment.TickCount); // Time?

			writer.Write((float)character.X);
			writer.Write((float)character.Y);
			writer.Write((float)character.Z);
			writer.Write((float)character.Rotation); // R

			// Movement speeds
			writer.Write((float)0);     // ????

			writer.Write((float)2.5f);  // MOVE_WALK
			writer.Write((float)7 * 10);     // MOVE_RUN
			writer.Write((float)4.5f);  // MOVE_RUN_BACK
			writer.Write((float)4.72f); // MOVE_SWIM
			writer.Write((float)2.5f);  // MOVE_SWIM_BACK
			writer.Write((float)3.14f); // MOVE_TURN_RATE

			writer.Write(0x1); // Unkown...

			entity = new PlayerEntity(character);
			entity.ObjectGUID = new ObjectGUID((ulong)character.GUID);
			entity.WriteUpdateFields(writer);

			return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
		}


        public static PSUpdateObject CreateCharacterUpdate(Character character)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

            byte[] guidBytes = GenerateGuidBytes((ulong)character.GUID);
            WriteBytes(writer, guidBytes, guidBytes.Length);


            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectFlags updateFlags = ObjectFlags.UPDATEFLAG_ALL |
                                      ObjectFlags.UPDATEFLAG_HAS_POSITION |
                                      ObjectFlags.UPDATEFLAG_LIVING;

            writer.Write((byte)updateFlags);

            writer.Write((UInt32)MovementFlags.MOVEFLAG_NONE);
            writer.Write((UInt32)Environment.TickCount); // Time?

            // Position
            writer.Write((float)character.X);
            writer.Write((float)character.Y);
            writer.Write((float)character.Z);
            writer.Write((float)0); // R

            // Movement speeds
            writer.Write((float)0);     // ????

            writer.Write((float)2.5f);  // MOVE_WALK
            writer.Write((float)7);     // MOVE_RUN
            writer.Write((float)4.5f);  // MOVE_RUN_BACK
            writer.Write((float)4.72f * 20); // MOVE_SWIM
            writer.Write((float)2.5f);  // MOVE_SWIM_BACK
            writer.Write((float)3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            new PlayerEntity(character).WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
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

		public static PSUpdateObject CreateGameObject(float x, float y, float z, GameObject gameObject, GameObjectTemplate template)
		{
			BinaryWriter writer = new BinaryWriter(new MemoryStream());
			writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

            GOEntity entity = new GOEntity(gameObject, template);

			byte[] guidBytes = GenerateGuidBytes(entity.ObjectGUID.RawGUID);

			for (int i = 0; i < guidBytes.Length; i++) writer.Write(guidBytes[i]);

			//BinaryReader reader = new BinaryReader(new MemoryStream(guidBytes));
		   // ulong lol = ReadPackedGuid(reader);

			//
			/*
			byte[] Guid = Helper.HexToByteArray("C7 E8 AB 02 C0 1F");
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
			//Console.WriteLine("----> " + BitConverter.ToUInt32(Guid, 0));

			writer.Write((byte)TypeID.TYPEID_GAMEOBJECT);

			ObjectFlags updateFlags = ObjectFlags.UPDATEFLAG_TRANSPORT |
									  ObjectFlags.UPDATEFLAG_ALL |
									  ObjectFlags.UPDATEFLAG_HAS_POSITION;

			writer.Write((byte)updateFlags);

			// Position

				writer.Write((float)x);
				writer.Write((float)y);
				writer.Write((float)z);
		 
			writer.Write((float)0); // R

			writer.Write((uint)0x1); // Unkown... time?
			writer.Write((uint)0); // Unkown... time?


		   entity.WriteUpdateFields(writer);

			return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() }, 1);
		}

        public static PSUpdateObject UpdateValues( ObjectEntity entity)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_VALUES);



            byte[] guidBytes = GenerateGuidBytes((ulong)entity.ObjectGUID.RawGUID);
            WriteBytes(writer, guidBytes, guidBytes.Length);

            //entity.SetUpdateField<float>((int)EObjectFields.OBJECT_FIELD_SCALE_X, (float)20f);
            //entity.SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION, (float)1f);
            //entity.SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_DISPLAYID, (uint)10);
            entity.WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() }, (entity is PlayerEntity) ? 0 : 1);
        }
        /*
        public static PSUpdateObject UpdateValues(WorldSession session, Character character)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_VALUES);


			
			byte[] guidBytes = GenerateGuidBytes((ulong)character.GUID);
			WriteBytes(writer, guidBytes, guidBytes.Length);



			BinaryWriter a = new BinaryWriter(new MemoryStream());
			PlayerEntity entity = new PlayerEntity(character);
			entity.WriteUpdateFields(a);


			entity.SetUpdateField<float>((int)EObjectFields.OBJECT_FIELD_SCALE_X, (float)2f);
			entity.SetUpdateField<UInt32>((int)EUnitFields.UNIT_FIELD_HEALTH, 20);
			entity.SetUpdateField<UInt32>((int)EUnitFields.UNIT_FIELD_LEVEL, 60);
			entity.WriteUpdateFields(writer);

			return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
		}
        */





















        public static PSUpdateObject CreateUnitUpdate(PlayerEntity character)
        {
            UnitEntity entity = new UnitEntity();

            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);
            //character
            byte[] guidBytes = GenerateGuidBytes((ulong)entity.ObjectGUID.RawGUID);
            WriteBytes(writer, guidBytes, guidBytes.Length);


            writer.Write((byte)TypeID.TYPEID_UNIT);

            ObjectFlags updateFlags = ObjectFlags.UPDATEFLAG_ALL |
                                      ObjectFlags.UPDATEFLAG_HAS_POSITION |
                                      ObjectFlags.UPDATEFLAG_LIVING;

            writer.Write((byte)updateFlags);

            writer.Write((UInt32)MovementFlags.MOVEFLAG_NONE);
            writer.Write((UInt32)Environment.TickCount); // Time?

            // Position
            writer.Write((float)character.X);
            writer.Write((float)character.Y);
            writer.Write((float)character.Z);
            writer.Write((float)0); // R

            // Movement speeds
            writer.Write((float)0);     // ????

            writer.Write((float)2.5f);  // MOVE_WALK
            writer.Write((float)7);     // MOVE_RUN
            writer.Write((float)4.5f);  // MOVE_RUN_BACK
            writer.Write((float)4.72f * 20); // MOVE_SWIM
            writer.Write((float)2.5f);  // MOVE_SWIM_BACK
            writer.Write((float)3.14f); // MOVE_TURN_RATE

            /*
            writer.Write((uint)0x0);
            writer.Write((uint)0x659);
            writer.Write((uint)0xB7B);
            writer.Write((uint)0xFDA0B4);    
            writer.Write((uint)0);

            for (int i = 0; i < 1; i++)
            {
                writer.Write((float)0);
                writer.Write((float)0);
                writer.Write((float)0);
            }
            */

            writer.Write(0x1); // Unkown...


            entity.WriteUpdateFields(writer);
            //new PlayerEntity(character).WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }

	}
}
