using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.World.Game.Entity
{
    using Vanilla.Core.Network.Session;

    public interface ISubscribable
    {
        List<Session> SubscribedBy { get; set; }

        byte[] CreatePacket { get; }

        byte[] UpdatePacket { get; }
    }
}
