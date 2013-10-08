using System;
using System.Collections.Generic;
using System.Linq;
using Vanilla.World.Game.Constants.Game.Update;
using Vanilla.World.Network;
using Vanilla.World.Tools.Shared;

namespace Vanilla.World.Tools.Update
{
    using Vanilla.Core;

    public class UpdateReader
    {
        public static void Boot()
        {
            String data = "01 00 00 00 00 02 CD B6 09 44 30 F1 03 70 00 00 00 00 4A FD 00 00 0B C4 13 C6 04 FF 75 42 AD 5E 5F 42 3A 4A 4E 40 00 00 00 00 00 00 20 40 F6 FF 1F 41 00 00 90 40 71 1C 97 40 00 00 20 40 E0 0F 49 40 01 00 00 00 06 1F 00 40 10 7C 4F 00 00 00 00 00 00 00 00 00 C0 DF 00 0A 00 38 18 00 00 B6 00 09 44 00 00 30 F1 09 00 00 00 44 00 00 00 00 00 80 3F 3B 12 00 00 3B 12 00 00 37 00 00 00 0B 00 00 00 00 01 02 00 3B 1D 00 00 20 08 00 00 02 07 FF 01 0D 03 00 00 04 06 01 0E 04 00 00 00 00 90 00 00 D0 07 00 00 DC 05 00 00 D0 07 00 00 F4 FD 54 3E 00 00 C0 3F 46 15 00 00 46 15 00 00 00 40 17 44 00 40 26 44 00 00 80 3F 01 00 00 00 3B 12 00 00 01 10 00 00 25 01 00 00 85 AB 96 43 C3 15 D3 43 ";
            ProccessLog(Helper.HexToByteArray(data));
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

            if(updateFlags.GetFlags().Contains(ObjectUpdateFlag.UPDATEFLAG_LIVING))
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

   

}
