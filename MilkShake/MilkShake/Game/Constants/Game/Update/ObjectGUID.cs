using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Game.Update
{
    public class ObjectGuid
    {
        public UInt64 Guid { get; set; }

        public ObjectGuid(ulong low, ulong id, HighGuid highType)
        {
            Guid = (ulong)(low | ((ulong)id << 32) | (ulong)highType << 52);
        }

        public static HighGuid GetGuidType(ulong guid)
        {
            return (HighGuid)(guid >> 52);
        }

        public static int GetId(ulong guid)
        {
            return (int)((guid >> 32) & 0xFFFFF);
        }

        public static ulong GetGuid(ulong guid)
        {
            return guid & 0xFFFFFFF;
        }
    }
}
