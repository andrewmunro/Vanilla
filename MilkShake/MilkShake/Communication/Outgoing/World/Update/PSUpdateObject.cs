using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Database;
using System.IO;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Tools.Update;
using Milkshake.Tools;
using Milkshake.Game.World.Entity;
using Milkshake.Net;

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

            writer.Write((float)character.X);
            writer.Write((float)character.Y);
            writer.Write((float)character.Z);
            writer.Write((float)character.Rotation); // R

            // Movement speeds
            writer.Write((float)0);     // ????

            writer.Write((float)2.5f);  // MOVE_WALK
            writer.Write((float)7);     // MOVE_RUN
            writer.Write((float)4.5f);  // MOVE_RUN_BACK
            writer.Write((float)4.72f); // MOVE_SWIM
            writer.Write((float)2.5f);  // MOVE_SWIM_BACK
            writer.Write((float)3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...

            new Player(character).WriteUpdateFields(writer);

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
            writer.Write((UInt32)5567); // Time?

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

            new Player(character).WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }


        public static PSUpdateObject Poop(WorldSession session, Character character)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_MOVEMENT);

            byte[] guidBytes = GenerateGuidBytes((ulong)character.GUID);
            WriteBytes(writer, guidBytes, guidBytes.Length);


            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectFlags updateFlags = ObjectFlags.UPDATEFLAG_HAS_POSITION;
                                      

            writer.Write((byte)updateFlags);

            writer.Write((UInt32)MovementFlags.MOVEFLAG_NONE);
            //writer.Write((UInt32)55675); // Time?

            // Position
            writer.Write((float)1);
            writer.Write((float)0);
            writer.Write((float)0);
            writer.Write((float)0); // R
            /*
            // Movement speeds
            writer.Write((float)0);     // ????

            writer.Write((float)2.5f);  // MOVE_WALK
            writer.Write((float)7 * 20);     // MOVE_RUN
            writer.Write((float)4.5f);  // MOVE_RUN_BACK
            writer.Write((float)4.72f * 20); // MOVE_SWIM
            writer.Write((float)2.5f);  // MOVE_SWIM_BACK
            writer.Write((float)3.14f); // MOVE_TURN_RATE

            writer.Write(0x1); // Unkown...
            */
            //new Player(character).WriteUpdateFields(writer);

            return new PSUpdateObject(new List<byte[]> { (writer.BaseStream as MemoryStream).ToArray() });
        }

    }
}
