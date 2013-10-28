namespace Vanilla.World.Game.Entity
{
    using System;
    using System.Reflection;

    public struct UpdateFieldEntry
    {
        public PropertyInfo PropertyInfo { get; set; }
        public Byte UpdateField { get; set; }
    }
}
