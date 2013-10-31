namespace Vanilla.World.Game.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    using PropertyChanged;
    using Vanilla.Core.Logging;

    [ImplementPropertyChanged]
    public class EntityInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<UpdateFieldEntry> CreationUpdateFieldEntries = new List<UpdateFieldEntry>();

        [UpdateField(EObjectFields.OBJECT_FIELD_GUID)]
        public ulong GUID { get; set; }

        [UpdateField(EObjectFields.OBJECT_FIELD_TYPE)]
        public byte Type { get; set; }

        [UpdateField(EObjectFields.OBJECT_FIELD_SCALE_X)]
        public float Scale { get; set; }

        public EntityInfo(ObjectGUID guid)
        {
            GUID = guid.RawGUID;

            foreach (var property in this.GetType().GetProperties())
            {
                UpdateField updateField = property.GetCustomAttribute<UpdateField>();
                if (updateField != null && updateField.RequiredOnCreation)
                {
                    Log.Print(property.GetMethod.Name);

                    CreationUpdateFieldEntries.Add(new UpdateFieldEntry()
                    {
                        PropertyInfo = property,
                        UpdateField = updateField.Enum,
                        Index = updateField.Index
                    });
                }
            }

            
        }
    }
}
