using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Update;

namespace Milkshake.Game.Entitys
{
    public class ObjectGUID
    {
        private static Dictionary<TypeID, uint> Indexes = new Dictionary<TypeID, uint>();


        public static ObjectGUID GetUnitGUID()
        {
            return new ObjectGUID(TypeID.TYPEID_UNIT, HighGUID.HIGHGUID_MO_TRANSPORT);
        }

        public static ObjectGUID GetGameObjectGUID()
        {
            return new ObjectGUID(TypeID.TYPEID_OBJECT, HighGUID.HIGHGUID_MO_TRANSPORT);
        }

        public static ObjectGUID GetGameObjectGUID(uint index)
        {
            return new ObjectGUID(index, TypeID.TYPEID_OBJECT, HighGUID.HIGHGUID_MO_TRANSPORT);
        }

        private static uint GetIndex(TypeID type)
        {
            if (!Indexes.ContainsKey(type)) Indexes.Add(type, 0);

            return Indexes[type]++;
        }

        // ----------------------------------------------------------------------------

        public ulong RawGUID { get; private set; }
        public uint Low { get { return (uint)(RawGUID & (ulong)0x0000000000FFFFFF); } }

        public ObjectGUID(ulong GUID)
        {
            RawGUID = GUID;
        }

        public ObjectGUID(uint index, TypeID type, HighGUID high)
        {
            RawGUID = (ulong)((ulong)index |
                      ((ulong)type << 24) |
                      ((ulong)high << 48));
        }

        public ObjectGUID(TypeID type, HighGUID high) : this(GetIndex(type), type, high) { }



        


    }
}
