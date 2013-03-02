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
        }

        public static void OnNameQueryPacket(WorldSession session, PCNameQuery packet)
        {
            Character target = DBCharacters.Characters.Find(character => character.GUID == packet.GUID);

            if (target != null)
            {
                session.sendPacket(new PSNameQuery(target));
            }
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
    }
}
