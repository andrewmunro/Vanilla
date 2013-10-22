namespace Vanilla.World.Game.Update
{
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.World.Game.Entity;
    using Vanilla.World.Network;

    public class UpdatePacketBuilder
    {
        public WorldSession Session { get; set; }

        private List<Entity> createEntities { get; set; }

        private List<Entity> updateEntities { get; set; }

        private List<Entity> removeEntities { get; set; }

        private BinaryWriter Packet = null;

        public byte[] Data { get; internal set; }

        public string Info { get; internal set; }

        public UpdatePacketBuilder(WorldSession session)
        {
            Session = session;
            createEntities = new List<Entity>();
            updateEntities = new List<Entity>();
            removeEntities = new List<Entity>();
        }

        public void Subscribe(Entity entity)
        {
            Packet = null;
            createEntities.Add(entity);
            entity.SubscribedBy.Add(Session);
        }

        public void UnSubscribe(Entity entity)
        {
            Packet = null;
            removeEntities.Remove(entity);
            removeEntities.Add(entity);
            entity.SubscribedBy.Remove(Session);
        }

        public void Update()
        {
            // Don't rebuild packet if nothing has changed
            if (Packet != null)
            {
                Session.SendPacket(Packet);
                return;
            }

            Packet = new BinaryWriter(new MemoryStream());

            if (createEntities.Count > 0)
            {
                Packet.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

                foreach (Entity entity in createEntities)
                {
                    Packet.Write(entity.CreatePacket);
                }
            }
        }
    }
}
