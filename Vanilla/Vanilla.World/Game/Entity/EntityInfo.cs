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
        public event PropertyChangedEventHandler PropertyChanged;

        [Enum(EGameObjectFields.GAMEOBJECT_POS_X)]
        public float X { get; set; }

    }
}
