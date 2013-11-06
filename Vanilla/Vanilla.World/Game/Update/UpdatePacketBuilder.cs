namespace Vanilla.World.Game.Update
{
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Object;
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

        public void Subscribe(ObjectEntity<ObjectInfo, EntityPacketBuilder> entity)
        {
            createEntities.Enqueue(entity);
            entity.SubscribedBy.Add(Session);
        }

        public void UnSubscribe(ObjectEntity<ObjectInfo, EntityPacketBuilder> entity)
        {
            updateEntities.Remove(entity);
            removeEntities.Enqueue(entity);
            entity.SubscribedBy.Remove(Session);
        }

        public void Update()
        {
            if (Session.Player == null) return;
            var entities = Session.Core.EntityManager.GetEntitiesInRadius(Session.Player.Location.Position, 50f);

            BinaryWriter packet = new BinaryWriter(new MemoryStream());

            if (createEntities.Count > 0)
            {
                packet.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

                foreach (ObjectEntity<ObjectInfo, EntityPacketBuilder> entity in createEntities)
                {
                    packet.Write(entity.CreatePacket);
                }
            }
        }
    }
}
