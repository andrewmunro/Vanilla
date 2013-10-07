using Vanilla.World.Game.Constants.Game.Update;
using Vanilla.World.Tools.Shared;

namespace Vanilla.World.Game.Entitys
{
    public class ObjectEntity : EntityBase
    {
        public ObjectGUID ObjectGUID { get; set; }

        public override int DataLength
        {
            get { return (int)EObjectFields.OBJECT_END; }
        }

        public ulong GUID
        {
            get { return ObjectGUID.RawGUID; }
            set { SetUpdateField<ulong>((int)EObjectFields.OBJECT_FIELD_GUID, value); }
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
            GUID = ObjectGUID.RawGUID;
        }
    }
}
   