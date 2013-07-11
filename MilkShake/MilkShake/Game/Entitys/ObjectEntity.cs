using System;
using System.Linq;
using System.Collections;
using System.IO;
using Milkshake.Game.Constants.Game.Update;
using System.Collections.Generic;

namespace Milkshake.Game.Entitys
{
    public class ObjectEntity : EntityBase
    {
        public ObjectGUID ObjectGUID { get; set; }

        public override int DataLength
        {
            get { return (int)EObjectFields.OBJECT_END; }
        }

        public uint GUID
        {
            get { return (uint)UpdateData[(int)EObjectFields.OBJECT_FIELD_GUID]; }
            set { SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_GUID, value); }
        }

        public int Data
        {
            get { return (int)UpdateData[(int)EObjectFields.OBJECT_FIELD_DATA]; }
            set { SetUpdateField<int>((int)EObjectFields.OBJECT_FIELD_DATA, value); }
        }

        public byte Type
        {
            get { return (byte)UpdateData[(int)EObjectFields.OBJECT_FIELD_TYPE]; }
            set { SetUpdateField<byte>((int)EObjectFields.OBJECT_FIELD_TYPE, value); }
        }

        public byte Entry
        {
            get { return (byte)UpdateData[(int)EObjectFields.OBJECT_FIELD_ENTRY]; }
            set { SetUpdateField<byte>((int)EObjectFields.OBJECT_FIELD_ENTRY, value); }
        }
        
        public float Scale
        {
            get { return (float)UpdateData[(int)EObjectFields.OBJECT_FIELD_SCALE_X]; }
            set { SetUpdateField<float>((int)EObjectFields.OBJECT_FIELD_SCALE_X, value); }
        }

        public ObjectEntity(ObjectGUID objectGUID)
        {
            ObjectGUID = objectGUID;
            GUID = (uint)ObjectGUID.RawGUID;
        }
    }
}
   