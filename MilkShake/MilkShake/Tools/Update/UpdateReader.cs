using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Network;
using Milkshake.Communication.Outgoing.World;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Tools.Extensions;


namespace Milkshake.Tools.Update
{
    public class UpdateReader
    {
        public static void Boot()
        {
            List<string> logs = Directory.GetFiles(Environment.CurrentDirectory + "/Logs").ToList();
            
            logs.ForEach(log => 
            {
                Console.WriteLine("Reading: " + log.Split('/')[log.Split('/').Length - 1]);
                ProccessLog(Helper.HexToByteArray(File.ReadAllText(log)));
            });

            Console.WriteLine("");
            guids.ForEach(p =>
            {
                byte[] bytes = BitConverter.GetBytes(p);
                Console.WriteLine(bytes[0] + " " + bytes[1]);
            });
        }
        static List<UInt16> guids = new List<ushort>();

        public static void ProccessLog(byte[] data)
        {
            PacketReader reader = new PacketReader(data);

            Console.WriteLine("  Block Count: " + reader.ReadUInt32());
            Console.WriteLine("  HasTransport: " + reader.ReadByte());
            ObjectUpdateType objectUpdateType = (ObjectUpdateType)reader.ReadByte();
            Console.WriteLine("  UpdateType: " + objectUpdateType);

            UInt16 guid = reader.ReadUInt16();
            guids.Add(guid);

            Console.WriteLine("  GUID: " + guid);
            Console.WriteLine("  ObjectType: " + (TypeID)reader.ReadByte());

            Console.WriteLine("  Update Flags");
            ObjectFlags updateFlags = (ObjectFlags)reader.ReadByte();
            updateFlags.GetIndividualFlags().ToList().ForEach(a => Console.WriteLine("   - " + a.ToString()));

            MovementFlags movemenFlags = (MovementFlags)reader.ReadUInt32();
            if (updateFlags.GetFlags().Contains(ObjectFlags.UPDATEFLAG_LIVING))
            {
                Console.WriteLine("  Movement Flags");
                
                movemenFlags.GetIndividualFlags().ToList().ForEach(a => Console.WriteLine("   - " + a.ToString()));

                UInt32 time = reader.ReadUInt32();
            }

            if (updateFlags.GetFlags().Contains(ObjectFlags.UPDATEFLAG_HAS_POSITION))
            {
                double X = reader.ReadSingle();
                double Y = reader.ReadSingle();
                double Z = reader.ReadSingle();
                double R = reader.ReadSingle();

                Console.WriteLine("  Position X:" + X + " Y:" + Y + " Z:" + Z + " R:" + R);
            }

            if (updateFlags.GetFlags().Contains(ObjectFlags.UPDATEFLAG_LIVING))
            {
                reader.ReadSingle(); // >

                Console.WriteLine("   MOVE_WALK:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_RUN:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_RUN_BACK:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_SWIM:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_SWIM_BACK:" + reader.ReadSingle());
                Console.WriteLine("   MOVE_TURN_RATE:" + reader.ReadSingle());
            }

            if (updateFlags.GetFlags().Contains(ObjectFlags.UPDATEFLAG_ALL))
            {
                Console.WriteLine(reader.ReadUInt32().ToString("X2"));
            }

            
           // byte blockCount = reader.ReadByte();
           // Console.WriteLine("blockCount: " + blockCount);
            //int maskSize = blockCount << 2;
           // byte[] ddddd = reader.ReadBytes((int)reader.BaseStream.Length - (int)reader.BaseStream.Position);

           // Console.WriteLine(Helper.ByteArrayToHex(ddddd));

            UpdateMask updateMask = ReadUpdateMask(reader);
            

            for (int i = 0; i < updateMask.HighestIndex; ++i)
            {
                if (updateMask.GetBit(i))
                {
                    int value = (int)reader.ReadUInt32();

                    if (Enum.IsDefined(typeof(EUnitFields), i)) Console.WriteLine((EUnitFields)i + " " + value);
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
