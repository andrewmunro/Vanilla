namespace Vanilla.World.Game.Entity
{
    using System;

    using Vanilla.Core.Tools;

    public interface IUnitEntity<out T, out TU> : ISubscribable
    {
        String Name { get; }
        Location Location { get; set; }
    }
}
