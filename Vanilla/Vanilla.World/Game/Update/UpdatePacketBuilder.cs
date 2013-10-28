namespace Vanilla.World.Game.Update
{
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Update.Constants;
    using Vanilla.World.Network;

    public class UpdatePacketBuilder
    {
        public WorldSession Session { get; set; }

        private Queue<Entity> createEntities { get; set; }

        private List<Entity> updateEntities { get; set; }

        private Queue<Entity> removeEntities { get; set; }

        public UpdatePacketBuilder(WorldSession session)
        {
            Session = session;
            createEntities = new Queue<Entity>();
            updateEntities = new List<Entity>();
            removeEntities = new Queue<Entity>();
        }

        public void Subscribe(Entity entity)
        {
            createEntities.Enqueue(entity);
            entity.SubscribedBy.Add(Session);
        }

        public void UnSubscribe(Entity entity)
        {
            updateEntities.Remove(entity);
            removeEntities.Enqueue(entity);
            entity.SubscribedBy.Remove(Session);
        }

        public void Update()
        {
            BinaryWriter packet = new BinaryWriter(new MemoryStream());

            if (createEntities.Count > 0)
            {
                packet.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

                foreach (Entity entity in createEntities)
                {
                    packet.Write(entity.CreatePacket);
                }
            }
        }
    }
}
