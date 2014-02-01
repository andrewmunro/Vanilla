namespace Vanilla.World.Game.Entity.Object
{
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Tools;

    public class ObjectInfo : EntityInfo
    {
        public ObjectInfo(ObjectGUID guid)
        {
            GUID = guid.RawGUID;
            Type = (byte)guid.TypeID;
            Scale = 1;
        }

        [UpdateField(EObjectFields.OBJECT_FIELD_GUID)]
        public ulong GUID { get; set; }

        [UpdateField(EObjectFields.OBJECT_FIELD_TYPE)]
        public byte Type { get; set; }

        [UpdateField(EObjectFields.OBJECT_FIELD_ENTRY)]
        public int Entry { get; set; }

        [UpdateField(EObjectFields.OBJECT_FIELD_SCALE_X)]
        public float Scale { get; set; }

        [UpdateField(EObjectFields.OBJECT_FIELD_PADDING)]
        public int Padding { get; set; }
    }
}
