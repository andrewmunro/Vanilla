using System.Collections.Generic;

namespace Vanilla.World.Game.Entity
{
    using Vanilla.Core.Network.Session;

    public interface ISubscribable
    {
        List<Session> SubscribedBy { get; set; }

        byte[] CreatePacket { get; }

        byte[] UpdatePacket { get; }

        ObjectGUID ObjectGUID { get; set; }

        bool Updated { get; }
    }
}
