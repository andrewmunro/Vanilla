namespace Vanilla.World.Communication.Outgoing.World.Entity
{
    #region

    using System;
    using System.Text;

    using Vanilla.Core.Opcodes;

    #endregion

    public class PSGameObjectQueryResponse : ServerPacket
    {
        #region Constructors and Destructors

        public PSGameObjectQueryResponse(GameObjectTemplate gameObjectTemplate)
            : base(WorldOpcodes.SMSG_GAMEOBJECT_QUERY_RESPONSE)
        {
            Write((UInt32)gameObjectTemplate.Entry);
            Write((UInt32)gameObjectTemplate.Type);
            Write((UInt32)gameObjectTemplate.DisplayID);
            Write(Encoding.UTF8.GetBytes(gameObjectTemplate.Name));
            Write((UInt16)0);
            Write((byte)0);
            Write((byte)0);

            // 24 byte clear
            Write((short)0);
        }

        #endregion
    }
}