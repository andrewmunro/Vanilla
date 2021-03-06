﻿namespace Vanilla.World.Game.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    using PropertyChanged;

    using Vanilla.World.Game.Entity.Tools;

    [ImplementPropertyChanged]
    public class EntityInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<UpdateFieldEntry> CreationUpdateFieldEntries = new List<UpdateFieldEntry>();

        public EntityInfo()
        {
            foreach (var property in this.GetType().GetProperties())
            {
                var updateField = property.GetCustomAttribute<UpdateField>();
                if (updateField != null && updateField.RequiredOnCreation)
                {
                    AddUpdateField(property, updateField);
                }
            }
        }

        protected void AddUpdateField(PropertyInfo property, UpdateField updateField)
        {
            CreationUpdateFieldEntries.Add(new UpdateFieldEntry()
            {
                PropertyInfo = property,
                UpdateField = updateField.Enum,
                Index = updateField.Index
            });
        }
    }
}
