namespace Vanilla.World.Game.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
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

        public EntityInfo Info;

        public List<Session> SubscribedBy = new List<Session>(); 

        protected EntityUpdatePacketBuilder updateBuilder;

        public Entity()
        {
            Info = new EntityInfo();
            Info.PropertyChanged += OnInfoPropertyChanged;

            Info.X = 5;
        }

        private void OnInfoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (SubscribedBy.Count == 0) return;

            if (!Info.UpdateFieldCache.ContainsKey(e.PropertyName))
            {
                var updateField = new UpdateField();
                updateField.PropertyInfo = Info.GetType().GetProperty(e.PropertyName);
                updateField.UpdateFieldEnum = updateField.PropertyInfo.GetCustomAttribute<EnumAttribute>().Enum;
                Info.UpdateFieldCache[e.PropertyName] = updateField;
            }
            updateBuilder.UpdateQueue.Enqueue(Info.UpdateFieldCache[e.PropertyName]);
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
