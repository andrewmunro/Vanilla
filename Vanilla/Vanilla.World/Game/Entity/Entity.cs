namespace Vanilla.World.Game.Entity
{
    using System.Collections.Generic;

    using Vanilla.Core.Network.Session;

    public class Entity
    {
        public byte[] CreatePacket
        {
            get
            {
                return updateBuilder.CreatePacket();
            }
        }

        public byte[] UpdatePacket
        {
            get
            {
                return updateBuilder.UpdatePacket();
            }
        }

        public List<Session> SubscribedBy; 

        protected IEntityUpdatePacketBuilder updateBuilder;

        public Entity()
        {
            SubscribedBy = new List<Session>();
        }

        public void Update()
        {
            if (SubscribedBy.Count == 0)
            {
                //Put in some sort of timer.
                EntityRegister.Dispose(this);
            }

            //If one of the properties changes, null the packets.
            updateBuilder.resetCreatePacket();
            updateBuilder.resetUpdatePacket();
        }
    }
}
