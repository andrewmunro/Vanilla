using System;
using Vanilla.World.Communication.Outgoing.World.Update;
using Vanilla.World.Game.Constants.Game.Update;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Movement
{
    using Vanilla.Core.Opcodes;

    public class PSMoveHeartbeat : ServerPacket
    {
        public PSMoveHeartbeat(Character character) : base(WorldOpcodes.MSG_MOVE_HEARTBEAT)
        {
            byte[] packedGUID = PSUpdateObject.GenerateGuidBytes((ulong)character.GUID);
            PSUpdateObject.WriteBytes(this, packedGUID);
            Write((UInt32)MovementFlags.MOVEFLAG_NONE);
            Write((UInt32)1); // Time
            Write(character.X);
            Write(character.Y);
            Write(character.Z);
            Write(character.Rotation);
            Write((UInt32)0); // ?
        }
    }
}
