using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Movement;
using Milkshake.Game.World.Chat;
using Milkshake.Net;
using Milkshake.Tools.Database;

namespace Milkshake.Game.World
{
    class MovementManager
    {
        public MovementManager(WorldSession session, Opcodes code, MoveInfo data)
        {
            ChatManager.SendSytemMessage(session, "PlayerX: " + data.X + " PlayerY: " + data.Y + " PlayerZ: " + data.Z + " PlayerR: " + data.R);

            session.Character.X = data.X;
            session.Character.Y = data.Y;
            session.Character.Z = data.Z;
            session.Character.Rotation = data.R;

            DBCharacters.UpdateCharacter(session.Character);
            //if (data.Transport.Y != null) ChatManager.SendSytemMessage(session, "Player Falling: " + data.Transport.Z);
        }
    }
}
