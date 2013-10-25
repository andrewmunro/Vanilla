namespace Vanilla.World.Game.Entity
{
    using System;
    using System.Reflection;

    public struct UpdateField
    {
        public PropertyInfo PropertyInfo { get; set; }
        public Byte Enum { get; set; }
    }
}
