using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Movement;
using Milkshake.Game.World.Chat;
using Milkshake.Net;

namespace Milkshake.Game.World
{
    class MovementManager
    {
        public MovementManager(WorldSession session, Opcodes code, MoveInfo data)
        {
            ChatManager.SendSytemMessage(session, "PlayerX: " + data.X + " PlayerY: " + data.Y + " PlayerZ: " + data.Z + " PlayerR: " + data.R);

            if (data.Transport.Y != null) ChatManager.SendSytemMessage(session, "Player Falling: " + data.Transport.Z);
        }
    }
}
