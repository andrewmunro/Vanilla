namespace Vanilla.World.Game.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using Vanilla.Core.Network.Session;
    using Vanilla.World.Game.Entity.UpdateBuilder;

    public class Entity
    {
        public byte[] CreatePacket { get { return this.PacketBuilder.CreatePacket(); } }

        public byte[] UpdatePacket { get { return this.PacketBuilder.UpdatePacket(); } }

        public EntityInfo Info;

        public ObjectGUID ObjectGUID;

        public List<Session> SubscribedBy = new List<Session>(); 

        public EntityPacketBuilder PacketBuilder;

        public Entity()
        {
           
        }

        public virtual void Setup()
        {
            Info.PropertyChanged += OnInfoPropertyChanged;
        }

        private void OnInfoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (SubscribedBy.Count == 0) return;
            
            UpdateFieldEntry updateFieldEntry = new UpdateFieldEntry();
            updateFieldEntry.PropertyInfo = Info.GetType().GetProperty(e.PropertyName);
            UpdateField updateField = updateFieldEntry.PropertyInfo.GetCustomAttribute<UpdateField>();

            if (updateField != null)
            {
                updateFieldEntry.UpdateField = updateField.Enum;
                if (!this.PacketBuilder.UpdateQueue.Contains(updateFieldEntry)) this.PacketBuilder.UpdateQueue.Enqueue(updateFieldEntry);
            }
        }

        public void Update()
        {
            if (SubscribedBy.Count == 0)
            {
                //Put in some sort of timer.
             //   EntityRegister.Dispose(this);
            }
        }
    }
}
