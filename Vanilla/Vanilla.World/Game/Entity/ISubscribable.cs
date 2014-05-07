using System.Collections.Generic;
using System.Collections.ObjectModel;

using Vanilla.World.Network;

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

        string Name { get; }

        void OnEntityCreatedForSession(WorldSession session);
    }
}
