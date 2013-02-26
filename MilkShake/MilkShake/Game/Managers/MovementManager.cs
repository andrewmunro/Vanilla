using System;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Movement;
using Milkshake.Communication.Outgoing.World.Movement;
using Milkshake.Net;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Game.Handlers;
using System.Collections.Generic;

namespace Milkshake.Game.Managers
{
    public class MovementManager
    {
        private static readonly  List<Opcodes> MOVEMENT_CODES = new List<Opcodes>()
        {   
            Opcodes.MSG_MOVE_START_TURN_LEFT, 
            Opcodes.MSG_MOVE_START_TURN_RIGHT, 
            Opcodes.MSG_MOVE_START_STRAFE_LEFT, 
            Opcodes.MSG_MOVE_START_STRAFE_RIGHT, 
            Opcodes.MSG_MOVE_START_BACKWARD, 
            Opcodes.MSG_MOVE_START_FORWARD,
            Opcodes.MSG_MOVE_JUMP,
            Opcodes.MSG_MOVE_SET_FACING,
            Opcodes.MSG_MOVE_STOP,
            Opcodes.MSG_MOVE_STOP_STRAFE,
            Opcodes.MSG_MOVE_STOP_TURN,
            /* Opcodes.MSG_MOVE_HEARTBEAT */
        };

        public static void Boot()
        {
            MOVEMENT_CODES.ForEach(code => DataRouter.AddHandler<MoveInfo>(code, GenerateResponce(code)));

            DataRouter.AddHandler<MoveInfo>(Opcodes.MSG_MOVE_HEARTBEAT, OnHeartBeat);
        }

        private static void OnHeartBeat(WorldSession session, MoveInfo handler)
        {
            session.Character.X = handler.X;
            session.Character.Y = handler.Y;
            session.Character.Z = handler.Z;
            session.Character.Rotation = handler.R;

            DBCharacters.UpdateCharacter(session.Character);
        }

        private static ProcessPacketCallbackTypes<MoveInfo> GenerateResponce(Opcodes opcode)
        {
            return delegate(WorldSession session, MoveInfo handler) { TransmitMovement(session, handler, opcode); };
        }

        private static void TransmitMovement(WorldSession session, MoveInfo handler, Opcodes code)
        {
            WorldServer.Sessions.FindAll(s => s != session).ForEach(s => s.sendPacket(new PSMovement(code, session.Character, handler)));
        }
    }
}
