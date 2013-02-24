using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Outgoing.World.Logout;
using Milkshake.Net;

namespace Milkshake.Game.World.Logout
{
    public class LogoutManager
    {
        public static void OnLogout(WorldSession session)
        {
            session.sendPacket(Opcodes.SMSG_LOGOUT_RESPONSE, new SCLogoutResponse().Packet);
        }
    }
}
