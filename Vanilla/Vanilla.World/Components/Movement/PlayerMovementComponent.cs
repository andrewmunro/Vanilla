namespace Vanilla.World.Components.Movement
{
    using System.Collections.Generic;

    using Vanilla.Core.Network;
    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Movement.Packets.Incoming;
    using Vanilla.World.Components.Movement.Packets.Outgoing;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Network;

    public class PlayerMovementComponent : WorldServerComponent
    {
        private readonly List<WorldOpcodes> MOVEMENT_CODES = new List<WorldOpcodes>()
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

        public PlayerMovementComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            MOVEMENT_CODES.ForEach(opcode => Router.AddHandler(opcode, GenerateResponse(opcode)));
            Router.AddHandler<PCMoveTimeSkipped>(WorldOpcodes.CMSG_MOVE_TIME_SKIPPED, OnMoveTimeSkipped);
            Router.AddHandler(WorldOpcodes.MSG_MOVE_WORLDPORT_ACK, OnWorldPort);
        }

        private void OnWorldPort(WorldSession session, PacketReader reader)
        {
            session.SendPacket(session.Player.PacketBuilder.BuildOwnCharacterPacket());
        }

        private void OnMoveTimeSkipped(WorldSession session, PCMoveTimeSkipped packet)
        {
            session.OutOfSyncDelay = packet.OutOfSyncDelay;
        }

        private void UpdateEntity(WorldSession session, PCMoveInfo handler)
        {
            session.Player.Location.X = handler.X;
            session.Player.Location.Y = handler.Y;
            session.Player.Location.Z = handler.Z;
        }

        private ProcessLoginPacketCallbackTypes<WorldSession, PCMoveInfo> GenerateResponse(WorldOpcodes worldOpcode)
        {
            return (session, handler) => TransmitMovement(session, handler, worldOpcode);
        }

        private void TransmitMovement(WorldSession session, PCMoveInfo handler, WorldOpcodes code)
        {
            UpdateEntity(session, handler);
            session.Player.SubscribedBy.ForEach(s => s.SendPacket(new PSMovement(code, session, handler)));
        }
    }
}
