using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Network;

namespace Milkshake.Tools.Update
{
    public enum ObjectUpdateType : byte
    {
        UPDATETYPE_VALUES = 0,
        UPDATETYPE_MOVEMENT = 1,
        UPDATETYPE_CREATE_OBJECT = 2,
        UPDATETYPE_CREATE_OBJECT2 = 3,
        UPDATETYPE_OUT_OF_RANGE_OBJECTS = 4,
        UPDATETYPE_NEAR_OBJECTS = 5
    }
    
    enum ObjectUpdateFlags : int
    {
        UPDATEFLAG_NONE = 0x0000,
        UPDATEFLAG_SELF = 0x0001,
        UPDATEFLAG_TRANSPORT = 0x0002,
        UPDATEFLAG_FULLGUID = 0x0004,
        UPDATEFLAG_HIGHGUID = 0x0008,
        UPDATEFLAG_ALL = 0x0010,
        UPDATEFLAG_LIVING = 0x0020,
        UPDATEFLAG_HAS_POSITION = 0x0040
    }
    
    enum TypeID
    {
        TYPEID_OBJECT        = 0,
        TYPEID_ITEM          = 1,
        TYPEID_CONTAINER     = 2,
        TYPEID_UNIT          = 3,
        TYPEID_PLAYER        = 4,
        TYPEID_GAMEOBJECT    = 5,
        TYPEID_DYNAMICOBJECT = 6,
        TYPEID_CORPSE        = 7
    };

    public class UpdateReader
    {
        [Flags]
        enum ObjectUpdateFlags : int
        {
            UPDATEFLAG_NONE = 0x0000,
            UPDATEFLAG_SELF = 0x0001,
            UPDATEFLAG_TRANSPORT = 0x0002,
            UPDATEFLAG_FULLGUID = 0x0004,
            UPDATEFLAG_HIGHGUID = 0x0008,
            UPDATEFLAG_ALL = 0x0010,
            UPDATEFLAG_LIVING = 0x0020,
            UPDATEFLAG_HAS_POSITION = 0x0040
        }

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
            Console.WriteLine("  UpdateType: " + reader.ReadByte());
            Console.WriteLine("  GUID: " + reader.ReadUInt16());
            Console.WriteLine("  ObjectType: " + reader.ReadByte());

            ObjectUpdateFlags updateFlags = (ObjectUpdateFlags)reader.ReadByte();

            Console.WriteLine("  Update Flags");
            updateFlags.GetIndividualFlags().ToList().ForEach(a => Console.WriteLine("   - " + a.ToString()));
        }
    }

    static class EnumExtensions
    {
        public static IEnumerable<Enum> GetFlags(this Enum value)
        {
            return GetFlags(value, Enum.GetValues(value.GetType()).Cast<Enum>().ToArray());
        }

        public static IEnumerable<Enum> GetIndividualFlags(this Enum value)
        {
            return GetFlags(value, GetFlagValues(value.GetType()).ToArray());
        }

        private static IEnumerable<Enum> GetFlags(Enum value, Enum[] values)
        {
            ulong bits = Convert.ToUInt64(value);
            List<Enum> results = new List<Enum>();
            for (int i = values.Length - 1; i >= 0; i--)
            {
                ulong mask = Convert.ToUInt64(values[i]);
                if (i == 0 && mask == 0L)
                    break;
                if ((bits & mask) == mask)
                {
                    results.Add(values[i]);
                    bits -= mask;
                }
            }
            if (bits != 0L)
                return Enumerable.Empty<Enum>();
            if (Convert.ToUInt64(value) != 0L)
                return results.Reverse<Enum>();
            if (bits == Convert.ToUInt64(value) && values.Length > 0 && Convert.ToUInt64(values[0]) == 0L)
                return values.Take(1);
            return Enumerable.Empty<Enum>();
        }

        private static IEnumerable<Enum> GetFlagValues(Type enumType)
        {
            ulong flag = 0x1;
            foreach (var value in Enum.GetValues(enumType).Cast<Enum>())
            {
                ulong bits = Convert.ToUInt64(value);
                if (bits == 0L)
                    //yield return value;
                    continue; // skip the zero value
                while (flag < bits) flag <<= 1;
                if (flag == bits)
                    yield return value;
            }
        }
    }

}
