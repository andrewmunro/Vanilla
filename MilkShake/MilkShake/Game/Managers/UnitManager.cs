using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Handlers;
using Milkshake.Communication.Incoming.World.Mail;
using Milkshake.Communication;
using Milkshake.Network;
using Milkshake.Net;
using Milkshake.Tools.Extensions;
using Milkshake.Game.Entitys;
using System.IO;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Communication.Outgoing.World.Entity;

namespace Milkshake.Game.Managers
{
    public class UnitManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PacketReader>(WorldOpcodes.CMSG_ATTACKSWING, OnAttackSwing);
            WorldDataRouter.AddHandler<PacketReader>(WorldOpcodes.CMSG_CREATURE_QUERY, OnCreatureQuery);

            

        }

        private static void OnCreatureQuery(WorldSession session, PacketReader handler)
        {
            uint entry = handler.ReadUInt32();
            ulong GUID = handler.ReadUInt64();

            UnitEntity entity = MilkShake.UnitComponent.Entitys.FindAll(u => u.ObjectGUID.RawGUID == GUID).First();

            session.sendPacket(new PSCreatureQueryResponce(entry, entity));
        }

        private static void OnAttackSwing(WorldSession session, PacketReader handler)
        {
            
            //ulong GUID = Milkshake.Communication.Outgoing.World.Update.PSUpdateObject.ReadPackedGuid(handler);
            //ObjectGUID OBJ = new ObjectGUID(GUID);
            //handler.ReadUInt32();
            //uint low = handler.ReadUInt32();

            ulong GUID = handler.ReadUInt64();


            List<UnitEntity> found = MilkShake.UnitComponent.Entitys.FindAll(u => u.ObjectGUID.RawGUID == GUID);


            UnitEntity targer = found.First();

            if(targer != null)
            {
                session.sendMessage("Attacking:" + targer.Name);
                ServerPacket packet = new ServerPacket(WorldOpcodes.SMSG_ATTACKSTART);
                packet.Write(session.Entity.ObjectGUID.RawGUID);
                packet.Write(targer.ObjectGUID.RawGUID);

                //entity.SetUpdateField<byte>((int)EUnitFields.UNIT_NPC_EMOTESTATE, (byte)int.Parse(attributeValue));

                //ServerPacket packet = new ServerPacket(WorldOpcodes.SMSG_ATTACKERSTATEUPDATE);

                session.sendPacket(packet);
            }
            else
            {
                session.sendMessage("Cant find");
            }
        }
    }
}
