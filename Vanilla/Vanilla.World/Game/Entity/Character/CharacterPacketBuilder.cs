namespace Vanilla.World.Game.Entity.Character
{
    using System;
    using System.IO;
    using Vanilla.Core;
    using Vanilla.Core.Constants.Character;
    using Vanilla.Core.Extensions;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.UpdateBuilder;
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

        public byte[] BuildOwnCharacterPacket()
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2);

            byte[] guidBytes = GenerateGuidBytes((ulong)1);
            WriteBytes(writer, guidBytes, guidBytes.Length);


            writer.Write((byte)TypeID.TYPEID_PLAYER);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL |
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

            writer.Write(Utils.HexToByteArray("29150040541DC0000000000080200000C0180402001000000006000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000900000019000000CDCCAC3F540000006400000054000000E80300006400000001000000060000000601000108000000990900000900000001000000D0070000D00700003B0000003B00000000EE11000000803F002800000700030006000002"));


            return (writer.BaseStream as MemoryStream).ToArray();
        }


    }
}
