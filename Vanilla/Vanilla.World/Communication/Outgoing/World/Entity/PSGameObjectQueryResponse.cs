namespace Vanilla.World.Communication.Outgoing.World.Entity
{
    #region

    using System;
    using System.Text;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Database.Models;

    #endregion

    public sealed class PSGameObjectQueryResponse : ServerPacket
    {
        #region Constructors and Destructors

        public PSGameObjectQueryResponse(GameObjectTemplate gameObjectTemplate)
            : base(WorldOpcodes.SMSG_GAMEOBJECT_QUERY_RESPONSE)
        {
            Write((uint)gameObjectTemplate.Entry);
            Write((uint)gameObjectTemplate.Type);
            Write((uint)gameObjectTemplate.DisplayId);
            Write(Encoding.UTF8.GetBytes(gameObjectTemplate.Name));
            Write((ushort)0);
            Write((byte)0);
            Write((byte)0);

            // 24 byte clear
            Write((short)0);
        }

        #endregion
    }
}