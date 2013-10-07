using Vanilla.World.Communication.Outgoing.World.Player;

namespace Vanilla.World.Tools.Chat.Commands
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
