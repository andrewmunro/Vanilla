namespace Vanilla.World.Game.Entity
{
    using System;

    using Vanilla.Core.Tools;

    public interface IUnitEntity : ISubscribable
    {
        String Name { get; }
        Location Location { get; set; }
    }
}
