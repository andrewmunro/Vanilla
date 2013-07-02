using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Game.Entitys;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Communication.Outgoing.World.Entity
{
    /*
             * WorldPacket data(SMSG_GAMEOBJECT_QUERY_RESPONSE, 150);
        data << uint32(entryID);
        data << uint32(info->type);
        data << uint32(info->displayId);
        data << Name;
        data << uint16(0) << uint8(0) << uint8(0);           // name2, name3, name4
        data.append(info->raw.data, 24);
        //data << float(info->size);                          // go size , to check
        SendPacket(&data);*/

    public class PSGameObjectQueryResponce : ServerPacket
    {
        public PSGameObjectQueryResponce(GameObjectTemplate gameObjectTemplate) : base(WorldOpcodes.SMSG_GAMEOBJECT_QUERY_RESPONSE)
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
