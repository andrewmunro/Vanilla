namespace Vanilla.World.Game.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    using PropertyChanged;

    [ImplementPropertyChanged]
    public class EntityInfo
    {
        public Dictionary<String, UpdateField> UpdateFieldCache = new Dictionary<string, UpdateField>();

        public event PropertyChangedEventHandler PropertyChanged;

        [Enum(EGameObjectFields.GAMEOBJECT_POS_X)]
        public float X { get; set; }

    }

    public struct UpdateField
    {
        public PropertyInfo PropertyInfo { get; set; }
        public Byte UpdateFieldEnum { get; set; }
    }
}
