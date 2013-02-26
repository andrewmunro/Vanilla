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

namespace Milkshake.Game.Managers
{
    public class MiscManager
    {
        public static void Boot()
        {
            DataRouter.AddHandler<PCNameQuery>(Opcodes.CMSG_NAME_QUERY, OnNameQueryPacket);
        }

        public static void OnNameQueryPacket(WorldSession session, PCNameQuery packet)
        {
            Character target = DBCharacters.Characters.Find(character => character.GUID == packet.GUID);

            if (target != null)
            {
                session.sendPacket(new PSNameQuery(target));
            }
        }
    }
}
