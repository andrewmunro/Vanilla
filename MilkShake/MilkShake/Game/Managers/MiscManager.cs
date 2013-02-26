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

namespace Milkshake.Game.Managers
{
    public class MiscManager
    {
        public static void Boot()
        {
            DataRouter.AddHandler<PCNameQuery>(Opcodes.CMSG_NAME_QUERY, OnNameQueryPacket);
            DataRouter.AddHandler<PCEmote>(Opcodes.CMSG_TEXT_EMOTE, OneEmotePacket);
        }

        public static void OnNameQueryPacket(WorldSession session, PCNameQuery packet)
        {
            Character target = DBCharacters.Characters.Find(character => character.GUID == packet.GUID);

            if (target != null)
            {
                session.sendPacket(new PSNameQuery(target));
            }
        }

        public static void OneEmotePacket(WorldSession session, PCEmote packet)
        {
            WorldServer.TransmitToAll(new PSEmote((int)packet.EmoteID, (int)session.Character.GUID));
        }
    }
}
