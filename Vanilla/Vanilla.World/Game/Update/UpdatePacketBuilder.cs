namespace Vanilla.World.Game.Update
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Vanilla.World.Components.Update.Packets.Outgoing;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Object;
    using Vanilla.World.Game.Entity.Object.Unit;
    using Vanilla.World.Game.Update.Constants;
    using Vanilla.World.Network;

    public class UpdatePacketBuilder
    {
        public WorldSession Session { get; set; }

        private Queue<ISubscribable> createEntities { get; set; }

        private List<ISubscribable> updateEntities { get; set; }

        private Queue<ISubscribable> removeEntities { get; set; }

        public UpdatePacketBuilder(WorldSession session)
        {
            Session = session;

            createEntities = new Queue<ISubscribable>();
            updateEntities = new List<ISubscribable>();
            removeEntities = new Queue<ISubscribable>();
        }

        public void Subscribe(ISubscribable entity)
        {
            createEntities.Enqueue(entity);
            entity.SubscribedBy.Add(Session);
        }

        public void UnSubscribe(ISubscribable entity)
        {
            updateEntities.Remove(entity);
            removeEntities.Enqueue(entity);
            entity.SubscribedBy.Remove(Session);
        }

        public void Update()
        {
            if (Session.Player == null) return;

            var entities = Session.Core.EntityManager.GetEntitiesInRadius(Session.Player.Location.Position, 5f);

            foreach (var entity in this.updateEntities.Where(entity => !entities.Contains(entity)).ToList())
            {
                this.UnSubscribe(entity);
            }

            foreach (var entity in entities.Where(entity => !this.updateEntities.Contains(entity)).ToList())
            {
                this.Subscribe(entity);
            }

            SendUpdatePacket();
        }

        private void SendUpdatePacket()
        {
            var packets = new List<byte[]>();

            while (createEntities.Count != 0)
            {
                var entity = createEntities.Dequeue();
                packets.Add(entity.CreatePacket);
                updateEntities.Add(entity);
            }

            Session.SendPacket(new PSUpdateObject(packets));
        }
    }
}
