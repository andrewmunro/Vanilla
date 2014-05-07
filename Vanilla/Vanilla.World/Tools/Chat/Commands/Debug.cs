using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Vanilla.World.Game.Entity.Object.Creature;
using Vanilla.World.Network;

namespace Vanilla.World.Tools.Chat.Commands
{
    [ChatCommandNode("debug", "Debug Commands")]
    public class Debug
    {
        [ChatCommand("come", "Makes NPC come to you!!")]
        public static void Send(WorldSession session, string[] args)
        {
            if(session.Player.Target != null || !(session.Player.Target is CreatureEntity))
            {
                var target = session.Player.Target as CreatureEntity;
                target.Brain.Move(session, new List<Vector3>(){session.Player.Location.Position});
            }
        }
    }
}
