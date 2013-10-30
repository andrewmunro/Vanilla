using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core;
using Vanilla.Core.Network.IO;
using Vanilla.World.Game.Entity;
using Vanilla.World.Game.Entity.Constants;
using Vanilla.World.Game.Update.Constants;
using Vanilla.Core.Extensions;

namespace Vanilla.World.Game.Update
{
    public class UpdateReader
    {
        public static void Boot()
        {
            String data = "01" + "00 00 00 00" + "03" + "01 01 04 71 00 00 00 00 AD 5E 00 00 7B 34 37 C5 E7 3B 85 C3 06 52 56 42 CA A9 49 3F 00 00 00 00 00 00 20 40 00 00 E0 40 00 00 90 40 71 1C 97 40 00 00 20 40 E0 0F 49 40 01 00 00 00 29 15 00 40 54 1D C0 00 00 00 00 00 80 20 00 00 C0 D9 04 C2 4F 38 19 00 00 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 E0 B6 6D DB B6 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 6C 80 00 00 00 00 00 00 80 00 40 00 00 80 3F 00 00 00 00 20 00 00 00 00 00 00 01 00 00 00 19 00 00 00 CD CC AC 3F 54 00 00 00 64 00 00 00 54 00 00 00 E8 03 00 00 64 00 00 00 01 00 00 00 06 00 00 00 06 01 00 01 08 00 00 00 99 09 00 00 09 00 00 00 01 00 00 00 D0 07 00 00 D0 07 00 00 D0 07 00 00 3B 00 00 00 3B 00 00 00 25 49 D2 40 25 49 F2 40 00 EE 11 00 00 00 80 3F 1C 00 00 00 0F 00 00 00 18 00 00 00 0F 00 00 00 16 00 00 00 1E 00 00 00 0A 00 00 00 14 00 00 00 00 28 00 00 27 00 00 00 06 00 00 00 DC B6 ED 3F 6E DB 36 40 07 00 07 01 02 00 00 01 90 01 00 00 1A 00 00 00 01 00 01 00 2C 00 00 00 01 00 05 00 36 00 00 00 01 00 05 00 5F 00 00 00 01 00 05 00 6D 00 00 00 2C 01 2C 01 73 00 00 00 2C 01 2C 01 A0 00 00 00 01 00 05 00 A2 00 00 00 01 00 05 00 9D 01 00 00 01 00 01 00 9E 01 00 00 01 00 01 00 9F 01 00 00 01 00 01 00 B1 01 00 00 01 00 01 00 02 00 00 00 48 E1 9A 40 3E 0A 17 3F 3E 0A 17 3F CD CC 0C 3F 00 00 04 00 29 00 00 00 0A 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F FF FF FF FF ";
            ProccessLog(Utils.HexToByteArray(data));
        }

        static List<UInt16> guids = new List<ushort>();




        public static void ProccessLog(byte[] data)
        {
            PacketReader reader = new PacketReader(data);

            Console.WriteLine("  Block Count: " + reader.ReadUInt32());
            Console.WriteLine("  HasTransport: " + reader.ReadByte());
            ObjectUpdateType objectUpdateType = (ObjectUpdateType)reader.ReadByte();
            Console.WriteLine("  UpdateType: " + objectUpdateType);


            ulong guid = 0;
            byte guidMask = reader.ReadByte();

            for (int i = 0; i < 8; i++)
            {
                if ((guidMask & (1 << i)) != 0)
                {
                    guid |= ((ulong)reader.ReadByte() << (i * 8));
                }
            }


            ObjectGUID hello = new ObjectGUID(guid);
            Console.WriteLine("GUID Low:" + hello.Low);
            Console.WriteLine("GUID Raw:" + hello.RawGUID);
            Console.WriteLine("GUID HIGH:" + hello.GetGuidType());
            Console.WriteLine("GUID ID:" + hello.GetId());

            //UInt16 guid = reader.ReadUInt16();
            //guids.Add(guid);



            Console.WriteLine("  GUID: " + guid);
            Console.WriteLine("  ObjectType: " + (TypeID)reader.ReadByte());

            Console.WriteLine("  Update Flags");
            ObjectUpdateFlag updateFlags = (ObjectUpdateFlag)reader.ReadByte();
            updateFlags.GetIndividualFlags().ToList().ForEach(b => Console.WriteLine("   - " + b.ToString()));

            if (updateFlags.GetFlags().Contains(ObjectUpdateFlag.UPDATEFLAG_LIVING))
            {
                MovementFlags movemenFlags = (MovementFlags)reader.ReadUInt32();
                if (updateFlags.GetFlags().Contains(ObjectUpdateFlag.UPDATEFLAG_LIVING))
                {
                    Console.WriteLine("  Movement Flags");

                    movemenFlags.GetIndividualFlags().ToList().ForEach(d => Console.WriteLine("   - " + d.ToString()));

                    UInt32 time = reader.ReadUInt32();
                }
            }

            if (updateFlags.GetFlags().Contains(ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION))
            {
                double X = reader.ReadSingle();
                double Y = reader.ReadSingle();
                double Z = reader.ReadSingle();
                double R = reader.ReadSingle();

                Console.WriteLine("  Position X:" + X + " Y:" + Y + " Z:" + Z + " R:" + R);
            }

            if (updateFlags.GetFlags().Contains(ObjectUpdateFlag.UPDATEFLAG_LIVING))
            {
                reader.ReadSingle(); // >

                Console.WriteLine("   MOVE_WALK:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_RUN:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_RUN_BACK:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_SWIM:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_SWIM_BACK:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_TURN_RATE:" + reader.ReadSingle());
            }

            if (updateFlags.GetFlags().Contains(ObjectUpdateFlag.UPDATEFLAG_ALL))
            {
                Console.WriteLine(reader.ReadUInt32());
            }

            if (updateFlags.GetFlags().Contains(ObjectUpdateFlag.UPDATEFLAG_TRANSPORT))
            {
                Console.WriteLine(reader.ReadUInt32());
            }


            // byte blockCount = reader.ReadByte();
            // Console.WriteLine("blockCount: " + blockCount);
            //int maskSize = blockCount << 2;
            // byte[] ddddd = reader.ReadBytes((int)reader.BaseStream.Length - (int)reader.BaseStream.Position);

            // Console.WriteLine(Helper.ByteArrayToHex(ddddd));

            UpdateMask updateMask = ReadUpdateMask(reader);

            Console.WriteLine("----------------------");

            for (int i = 0; i < updateMask.HighestIndex; ++i)
            {
                if (updateMask.GetBit(i))
                {
                    if (i == 0)
                    {
                        // ulong GUID = reader.ReadUInt64();
                    }
                    int value = (int)reader.ReadUInt32();

                    if (Enum.IsDefined(typeof(EObjectFields), i)) Console.WriteLine((EObjectFields)i + " " + value);
                    else if (Enum.IsDefined(typeof(EGameObjectFields), i)) Console.WriteLine((EGameObjectFields)i + " " + value);
                    else if (Enum.IsDefined(typeof(EUnitFields), i)) Console.WriteLine((EUnitFields)i + " " + value);
                    else if (Enum.IsDefined(typeof(EObjectFields), i)) Console.WriteLine((EObjectFields)i + " " + value);
                    else Console.WriteLine("Unkown " + i + " " + value);



                    /*
                     // GUID
                     if (i == 0)
                     {
                         byte[] raw = BitConverter.GetBytes(value);
                         Console.WriteLine("GUID: " + raw[0] + " " + raw[1] + " " + raw[2] + " " + raw[3]);
                     }
                     * */
                    //obj.SetUInt32Value((uint)i, value);
                }
            }




        }

        public static UpdateMask ReadUpdateMask(PacketReader reader)
        {
            byte blockCount = reader.ReadByte();
            if (blockCount == 0)
                return null;

            UpdateMask um = new UpdateMask(blockCount);

            for (int i = 0; i < blockCount; ++i)
                um.SetBlock((uint)i, reader.ReadUInt32());

            return um;
        }
    }

    public class UpdateMask
    {
        private int m_maxBlockCount;
        private uint[] m_blocks;

        protected internal int m_lowestIndex;
        protected internal int m_highestIndex;

        public UpdateMask(int blockcount)
        {
            m_maxBlockCount = blockcount;
            m_highestIndex = blockcount * 32;
            m_blocks = new uint[blockcount];
        }

        public int MaxBlockCount
        {
            get { return m_maxBlockCount; }
        }

        public uint[] Blocks
        {
            get { return m_blocks; }
        }

        public void SetBlock(uint i, uint x)
        {
            m_blocks[i] = x;
        }

        public int LowestIndex
        {
            get { return m_lowestIndex; }
        }

        public int HighestIndex
        {
            get
            {
                return m_highestIndex;
            }
        }

        public bool HasBitsSet
        {
            get
            {
                return m_highestIndex >= m_lowestIndex;
            }
        }

        public void UnsetBit(int index)
        {
            m_blocks[index >> 5] &= ~(uint)(1 << (index & 31));
        }

        public void SetAll()
        {
            for (int i = 0; i < m_maxBlockCount; i++)
            {
                m_blocks[i] = uint.MaxValue;
            }
        }

        public void SetBit(int index)
        {
            m_blocks[index >> 5] |= (uint)(1 << (index & 31));
            if (index > m_highestIndex)
            {
                m_highestIndex = index;
            }
            if (index < m_lowestIndex)
            {
                m_lowestIndex = index;
            }
        }

        public bool GetBit(int index)
        {
            return (m_blocks[index >> 5] & (uint)(1 << (index & 31))) != 0;
        }
    }

}
