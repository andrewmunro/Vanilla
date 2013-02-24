using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Network;
using Milkshake.Communication.Outgoing.World;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Game.Constants.Update;

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
                ProccessLog(Helper.StringToByteArray(File.ReadAllText(log)));
            });          
        }

        public static void ProccessLog(byte[] data)
        {
            PacketReader reader = new PacketReader(data);

            Console.WriteLine("  Block Count: " + reader.ReadUInt32());
            Console.WriteLine("  HasTransport: " + reader.ReadByte());
            Console.WriteLine("  UpdateType: " + (ObjectUpdateType)reader.ReadByte());
            Console.WriteLine("  GUID: " + reader.ReadUInt16());
            Console.WriteLine("  ObjectType: " + (TypeID)reader.ReadByte());

            ObjectFlags updateFlags = (ObjectFlags)reader.ReadByte();

            Console.WriteLine("  Update Flags");
            updateFlags.GetIndividualFlags().ToList().ForEach(a => Console.WriteLine("   - " + a.ToString()));


        }
    }

   

}
