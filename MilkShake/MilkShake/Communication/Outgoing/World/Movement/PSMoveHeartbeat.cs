using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Database;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Game.Constants.Game.Update;

namespace Milkshake.Communication.Outgoing.World.Movement
{
    public class PSMoveHeartbeat : ServerPacket
    {
        public PSMoveHeartbeat(Character character) : base(Opcodes.MSG_MOVE_START_FORWARD)
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
