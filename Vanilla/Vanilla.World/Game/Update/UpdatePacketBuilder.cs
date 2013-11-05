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

        private Queue<ObjectEntity<ObjectInfo, EntityPacketBuilder>> createEntities { get; set; }

        private List<ObjectEntity<ObjectInfo, EntityPacketBuilder>> updateEntities { get; set; }

        private Queue<ObjectEntity<ObjectInfo, EntityPacketBuilder>> removeEntities { get; set; }

        public UpdatePacketBuilder(WorldSession session)
        {
            Session = session;

            createEntities = new Queue<ObjectEntity<ObjectInfo, EntityPacketBuilder>>();
            updateEntities = new List<ObjectEntity<ObjectInfo, EntityPacketBuilder>>();
            removeEntities = new Queue<ObjectEntity<ObjectInfo, EntityPacketBuilder>>();
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

        private void refreshEntities()
        {

        }

        public void Update()
        {
            BinaryWriter packet = new BinaryWriter(new MemoryStream());

            refreshEntities();

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
