using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Game.Entitys;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Communication.Outgoing.World.Entity
{
    public class PSGameObjectQueryResponse : ServerPacket
    {
        public PSGameObjectQueryResponse(GameObjectTemplate gameObjectTemplate) : base(WorldOpcodes.SMSG_GAMEOBJECT_QUERY_RESPONSE)
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
            Write((byte)0); //
        }
    }
}
