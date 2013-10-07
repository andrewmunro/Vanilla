using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication.Outgoing.World.Player;
using Milkshake.Net;

namespace Milkshake.Tools.Chat.Commands
{
    [ChatCommandNode("emote", "Emote Commands")]
    public class Emote
    {
         [ChatCommand("chicken", "Sends chicken emote")]
         public static void Send(WorldSession session, string[] args)
         {
             session.sendPacket(new PSEmote(19, session.Entity.ObjectGUID.RawGUID));
         }
    }
}
