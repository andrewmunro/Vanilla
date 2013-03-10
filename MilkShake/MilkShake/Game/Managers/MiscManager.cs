using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Handlers;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World;
using Milkshake.Net;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Communication.Outgoing.World;
using Milkshake.Communication.Incoming.World.Player;
using Milkshake.Communication.Outgoing.World.Player;
using Milkshake.Tools.DBC;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Network;
using Milkshake.Game.Entitys;
using Milkshake.Communication.Incoming.World.GameObject;
using Milkshake.Communication.Outgoing.World.Entity;
using Milkshake.Game.Constants.Game.Update;

namespace Milkshake.Game.Managers
{
    public class MiscManager
    {
        public static void Boot()
        {
            DataRouter.AddHandler<PCNameQuery>(Opcodes.CMSG_NAME_QUERY, OnNameQueryPacket);
            DataRouter.AddHandler<PCTextEmote>(Opcodes.CMSG_TEXT_EMOTE, OnTextEmotePacket);
            DataRouter.AddHandler<PCZoneUpdate>(Opcodes.CMSG_ZONEUPDATE, OnZoneUpdatePacket);
            DataRouter.AddHandler<PCAreaTrigger>(Opcodes.CMSG_AREATRIGGER, OnAreaTriggerPacket);
            DataRouter.AddHandler<PCPing>(Opcodes.CMSG_PING, OnPingPacket);
            DataRouter.AddHandler<PCSetSelection>(Opcodes.CMSG_SET_SELECTION, OnSetSelectionPacket);
            DataRouter.AddHandler<PCGameObjectQuery>(Opcodes.CMSG_GAMEOBJECT_QUERY, OnGameObjectQuery);
        }

        public static void OnNameQueryPacket(WorldSession session, PCNameQuery packet)
        {
            Character target = DBCharacters.Characters.Find(character => character.GUID == packet.GUID);

            if (target != null)
            {
                session.sendPacket(new PSNameQueryResponce(target));
            }
        }

        public static void OnGameObjectQuery(WorldSession session, PCGameObjectQuery packet)
        {            
            GameObjectTemplate template = DBGameObject.GameObjectTemplates.Find(g => g.Entry == packet.EntryID);
            session.sendPacket(new PSGameObjectQueryResponce(template));
            session.sendMessage("Requested Info: " + template.Name + " " + (GameobjectTypes)template.Type);
        }

        public static void OnTextEmotePacket(WorldSession session, PCTextEmote packet)
        {
            WorldServer.TransmitToAll(new PSTextEmote((int)session.Character.GUID, (int)packet.EmoteID, (int)packet.TextID));
        }

        public static void OnZoneUpdatePacket(WorldSession session, PCZoneUpdate packet)
        {
            session.sendMessage("[ZoneUpdate] ID:" + packet.ZoneID + " " + DBC.AreaTable.First(a => a.ID == packet.ZoneID).Name);
        }

        public static void OnAreaTriggerPacket(WorldSession session, PCAreaTrigger packet)
        {
            session.sendMessage("[AreaTrigger] ID:" + packet.TriggerID);
        }

        public static void OnPingPacket(WorldSession session, PCPing packet)
        {
            session.sendMessage("Ping: " + packet.Ping + " Latancy: " + packet.Latency);

            session.sendPacket(new PSPong(packet.Ping));
        }

        public static void OnSetSelectionPacket(WorldSession session, PCSetSelection packet)
        {
            try
            {
                session.Entity.Target = WorldServer.Sessions.First(s => s.Entity.GUID.RawGUID == packet.GUID).Entity;

                session.sendMessage("Targeted: " + (session.Entity.Target as PlayerEntity).Character.Name);
            }
            catch (Exception e)
            {

            }

            //session.sendMessage("Ping: " + packet.Ping + " Latancy: " + packet.Latency);

           // session.sendPacket(new PSPong(packet.Ping));
        }
    }
}
