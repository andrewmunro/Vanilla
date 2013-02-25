using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Database;
using System.IO;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Game.Constants.Update;
using Milkshake.Tools.Update;
using Milkshake.Tools;

namespace Milkshake.Communication.Outgoing.World.Update
{
    public class PSUpdateObject : ServerPacket
    {
        public PSUpdateObject(List<byte[]> blocks) : base(Opcodes.SMSG_UPDATE_OBJECT)
        {
            Write((uint)blocks.Count());
            Write((byte)0); // Has transport

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

        public static PSUpdateObject CreateOwnCharacterUpdate(Character character)
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

            writer.Write(Helper.StringToByteArray("29 15 00 40 54 1D C0 00 00 00 00 00 80 20 00 00 C0 D9 04 C2 4F 38 19 00 00 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 E0 B6 6D DB B6 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 6C 80 00 00 00 00 00 00 80 00 40 00 00 80 3F 00 00 00 00 20 00 00 00 00 00 " + guidBytes[0].ToString("X2") + " " + guidBytes[1].ToString("X2") + "00 00 00 19 00 00 00 CD CC AC 3F 54 00 00 00 64 00 00 00 54 00 00 00 E8 03 00 00 64 00 00 00 01 00 00 00 06 00 00 00 06 01 00 01 08 00 00 00 99 09 00 00 09 00 00 00 01 00 00 00 D0 07 00 00 D0 07 00 00 D0 07 00 00 3B 00 00 00 3B 00 00 00 25 49 D2 40 25 49 F2 40 00 EE 11 00 00 00 80 3F 1C 00 00 00 0F 00 00 00 18 00 00 00 0F 00 00 00 16 00 00 00 1E 00 00 00 0A 00 00 00 14 00 00 00 00 28 00 00 27 00 00 00 06 00 00 00 DC B6 ED 3F 6E DB 36 40 07 00 07 01 02 00 00 01 90 01 00 00 1A 00 00 00 01 00 01 00 2C 00 00 00 01 00 05 00 36 00 00 00 01 00 05 00 5F 00 00 00 01 00 05 00 6D 00 00 00 2C 01 2C 01 73 00 00 00 2C 01 2C 01 A0 00 00 00 01 00 05 00 A2 00 00 00 01 00 05 00 9D 01 00 00 01 00 01 00 9E 01 00 00 01 00 01 00 9F 01 00 00 01 00 01 00 B1 01 00 00 01 00 01 00 02 00 00 00 48 E1 9A 40 3E 0A 17 3F 3E 0A 17 3F CD CC 0C 3F 00 00 04 00 29 00 00 00 0A 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F FF FF FF FF"));

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }


         public static PSUpdateObject CreateCharacterUpdate(Character character)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

            writer.Write((UInt16)2305);


            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectFlags updateFlags = ObjectFlags.UPDATEFLAG_ALL |
                                      ObjectFlags.UPDATEFLAG_HAS_POSITION |
                                      ObjectFlags.UPDATEFLAG_LIVING;

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

            writer.Write(Helper.StringToByteArray("29150040541DC0000000000080200000C0180402001000000006000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000900000019000000CDCCAC3F540000006400000054000000E80300006400000001000000060000000601000108000000990900000900000001000000D0070000D00700003B0000003B00000000EE11000000803F002800000700030006000002"));

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }
    }
}
