using System;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Movement;
using Milkshake.Communication.Outgoing.World.Movement;
using Milkshake.Net;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Game.Handlers;
using System.Collections.Generic;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Network;
using Milkshake.Tools;
using Milkshake.Game.Entitys;

namespace Milkshake.Game.Managers
{
    public class MovementManager
    {
        private static readonly List<Opcodes> MOVEMENT_CODES = new List<Opcodes>()
        {   
            Opcodes.MSG_MOVE_HEARTBEAT,
            Opcodes.MSG_MOVE_JUMP,
            Opcodes.MSG_MOVE_START_FORWARD,
            Opcodes.MSG_MOVE_START_BACKWARD,
            Opcodes.MSG_MOVE_SET_FACING,
            Opcodes.MSG_MOVE_STOP,
            Opcodes.MSG_MOVE_START_STRAFE_LEFT,
            Opcodes.MSG_MOVE_START_STRAFE_RIGHT,
            Opcodes.MSG_MOVE_STOP_STRAFE,
            Opcodes.MSG_MOVE_START_TURN_LEFT,
            Opcodes.MSG_MOVE_START_TURN_RIGHT,
            Opcodes.MSG_MOVE_STOP_TURN,
            Opcodes.MSG_MOVE_START_PITCH_UP,
            Opcodes.MSG_MOVE_START_PITCH_DOWN,
            Opcodes.MSG_MOVE_STOP_PITCH,
            Opcodes.MSG_MOVE_SET_RUN_MODE,
            Opcodes.MSG_MOVE_SET_WALK_MODE,
            Opcodes.MSG_MOVE_SET_PITCH,
            Opcodes.MSG_MOVE_START_SWIM,
            Opcodes.MSG_MOVE_STOP_SWIM,
            Opcodes.MSG_MOVE_FALL_LAND,
            Opcodes.MSG_MOVE_HOVER,
            Opcodes.MSG_MOVE_KNOCK_BACK
        };

        public static void Boot()
        {
            MOVEMENT_CODES.ForEach(code => DataRouter.AddHandler<PCMoveInfo>(code, GenerateResponce(code)));

            DataRouter.AddHandler(Opcodes.CMSG_MOVE_TIME_SKIPPED, OnMoveTimeSkipped);
            DataRouter.AddHandler(Opcodes.MSG_MOVE_WORLDPORT_ACK, OnWorldPort);
        }

        private static void OnWorldPort(WorldSession session, byte[] data)
        {
            PlayerEntity a;
            session.sendPacket(PSUpdateObject.CreateOwnCharacterUpdate(session.Character, out a));
            a.Session = session;
        }

        private static void OnMoveTimeSkipped(WorldSession session, byte[] packet)
        {
            PacketReader reader = new PacketReader(packet);
            PSUpdateObject.ReadPackedGuid(reader);
            session.OutOfSyncDelay = reader.ReadUInt32();

            session.sendMessage("[MoveTimeSkipped] OutOfSyncDelay: " + session.OutOfSyncDelay);            
            
        }

        private static void SavePosition(WorldSession session, PCMoveInfo handler)
        {
            session.Character.X = handler.X;
            session.Character.Y = handler.Y;
            session.Character.Z = handler.Z;
            session.Character.Rotation = handler.R;

            DBCharacters.UpdateCharacter(session.Character);
        }

        private static void UpdateEntity(WorldSession session, PCMoveInfo handler)
        {
            session.Entity.X = handler.X;
            session.Entity.Y = handler.Y;
            session.Entity.Z = handler.Z;
        }

        private static ProcessPacketCallbackTypes<PCMoveInfo> GenerateResponce(Opcodes opcode)
        {
            return delegate(WorldSession session, PCMoveInfo handler) { TransmitMovement(session, handler, opcode); };
        }

        private static void TransmitMovement(WorldSession session, PCMoveInfo handler, Opcodes code)
        {
            if (code == Opcodes.MSG_MOVE_HEARTBEAT)
            {
                SavePosition(session, handler);
            }


            UpdateEntity(session, handler);

            WorldServer.Sessions.FindAll(s => s != session).ForEach(s => s.sendPacket(new PSMovement(code, session, handler)));
        }
    }
}
