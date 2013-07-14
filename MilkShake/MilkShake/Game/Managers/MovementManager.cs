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
        private static readonly List<WorldOpcodes> MOVEMENT_CODES = new List<WorldOpcodes>()
        {   
            WorldOpcodes.MSG_MOVE_HEARTBEAT,
            WorldOpcodes.MSG_MOVE_JUMP,
            WorldOpcodes.MSG_MOVE_START_FORWARD,
            WorldOpcodes.MSG_MOVE_START_BACKWARD,
            WorldOpcodes.MSG_MOVE_SET_FACING,
            WorldOpcodes.MSG_MOVE_STOP,
            WorldOpcodes.MSG_MOVE_START_STRAFE_LEFT,
            WorldOpcodes.MSG_MOVE_START_STRAFE_RIGHT,
            WorldOpcodes.MSG_MOVE_STOP_STRAFE,
            WorldOpcodes.MSG_MOVE_START_TURN_LEFT,
            WorldOpcodes.MSG_MOVE_START_TURN_RIGHT,
            WorldOpcodes.MSG_MOVE_STOP_TURN,
            WorldOpcodes.MSG_MOVE_START_PITCH_UP,
            WorldOpcodes.MSG_MOVE_START_PITCH_DOWN,
            WorldOpcodes.MSG_MOVE_STOP_PITCH,
            WorldOpcodes.MSG_MOVE_SET_RUN_MODE,
            WorldOpcodes.MSG_MOVE_SET_WALK_MODE,
            WorldOpcodes.MSG_MOVE_SET_PITCH,
            WorldOpcodes.MSG_MOVE_START_SWIM,
            WorldOpcodes.MSG_MOVE_STOP_SWIM,
            WorldOpcodes.MSG_MOVE_FALL_LAND,
            WorldOpcodes.MSG_MOVE_HOVER,
            WorldOpcodes.MSG_MOVE_KNOCK_BACK
        };

        public static void Boot()
        {
            MOVEMENT_CODES.ForEach(code => WorldDataRouter.AddHandler<PCMoveInfo>(code, GenerateResponse(code)));

            WorldDataRouter.AddHandler(WorldOpcodes.CMSG_MOVE_TIME_SKIPPED, OnMoveTimeSkipped);
            WorldDataRouter.AddHandler(WorldOpcodes.MSG_MOVE_WORLDPORT_ACK, OnWorldPort);
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

        private static ProcessWorldPacketCallbackTypes<PCMoveInfo> GenerateResponse(WorldOpcodes worldOpcode)
        {
            return delegate(WorldSession session, PCMoveInfo handler) { TransmitMovement(session, handler, worldOpcode); };
        }

        private static void TransmitMovement(WorldSession session, PCMoveInfo handler, WorldOpcodes code)
        {
            if (code == WorldOpcodes.MSG_MOVE_HEARTBEAT)
            {
                SavePosition(session, handler);
            }

            session.Entity.X = handler.X;
            session.Entity.Y = handler.Y;
            session.Entity.Z = handler.Z;

            UpdateEntity(session, handler);

            World.SessionsWhoKnow(session.Entity).ForEach(s => s.sendPacket(new PSMovement(code, session, handler)));
        }
    }
}
