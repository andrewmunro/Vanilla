namespace Vanilla.World.Game.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    using Vanilla.Core.Logging;
    using Vanilla.Core.Network.Session;
    using Vanilla.World.Game.Entity.UpdateBuilder;

    public class Entity
    {
        public byte[] CreatePacket { get { return this.Builder.CreatePacket(); } }

        public byte[] UpdatePacket { get { return this.Builder.UpdatePacket(); } }

        public EntityInfo Info;

        public List<Session> SubscribedBy = new List<Session>(); 

        protected EntityPacketBuilder Builder;

        public Entity()
        {
            Info.PropertyChanged += OnInfoPropertyChanged;
        }

        private void OnInfoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (SubscribedBy.Count == 0) return;
            
            UpdateField updateField = new UpdateField();
            updateField.PropertyInfo = Info.GetType().GetProperty(e.PropertyName);
            updateField.Enum = updateField.PropertyInfo.GetCustomAttribute<EnumAttribute>().Enum;

            if (!this.Builder.UpdateQueue.Contains(updateField)) this.Builder.UpdateQueue.Enqueue(updateField);
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
