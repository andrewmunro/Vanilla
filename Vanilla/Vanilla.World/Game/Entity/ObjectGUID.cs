using System.Collections.Generic;

namespace Vanilla.World.Game.Entity
{
    using System;

    using Vanilla.World.Game.Entity.Constants;

    public class ObjectGUID
    {
        private static Dictionary<TypeID, uint> Indexes = new Dictionary<TypeID, uint>();

        public static ObjectGUID GetUnitGUID()
        {
            return new ObjectGUID(TypeID.TYPEID_UNIT, HighGUID.HIGHGUID_UNIT);
        }

        public static ObjectGUID GetUnitGUID(uint low)
        {
            return new ObjectGUID(low, TypeID.TYPEID_UNIT, HighGUID.HIGHGUID_UNIT);
        }

        public static ObjectGUID GetGameObjectGUID()
        {
            return new ObjectGUID(TypeID.TYPEID_GAMEOBJECT, HighGUID.HIGHGUID_GAMEOBJECT);
        }

        public static ObjectGUID GetGameObjectGUID(uint index)
        {
            return new ObjectGUID(index, TypeID.TYPEID_OBJECT, HighGUID.HIGHGUID_MO_TRANSPORT);
        }

        private static uint GetIndex(TypeID type)
        {
            if (!Indexes.ContainsKey(type)) Indexes.Add(type, 1);

            return Indexes[type]++;
        }

        // ----------------------------------------------------------------------------

        public ulong RawGUID { get; private set; }

        public uint Low { get { return (uint)(RawGUID & (ulong)0x0000000000FFFFFF); } }

        public TypeID TypeID { get; private set; }

        public HighGUID HighGUID { get; private set; }

        public ObjectGUID(ulong GUID, TypeID type)
        {
            RawGUID = GUID;
            TypeID = type;
        }

        public ObjectGUID(uint index, TypeID type, HighGUID high)
        {
            TypeID = type;
            HighGUID = high;

            RawGUID = (ulong)((ulong)index |
                      ((ulong)type << 24) |
                      ((ulong)high << 48));
        }

        public ObjectGUID(TypeID type, HighGUID high) : this(GetIndex(type), type, high) { }


        public TypeID GetId()
        {
            return (TypeID)((RawGUID >> 24) & 0xFFFFF);
        }

        public HighGUID GetGuidType()
        {
            return (HighGUID)(RawGUID >> 48);
        }

        public byte[] GetGuidBytes()
        {
            byte[] packedGuid = new byte[9];
            byte length = 1;

            var raw = RawGUID;

            for (byte i = 0; raw != 0; i++)
            {
                if ((raw & 0xFF) != 0)
                {
                    packedGuid[0] |= (byte)(1 << i);
                    packedGuid[length] = (byte)(RawGUID & 0xFF);
                    ++length;
                }

                raw >>= 8;
            }

            byte[] clippedArray = new byte[length];
            Array.Copy(packedGuid, clippedArray, length);

            return clippedArray;
        }
    }
}
