using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication.Incoming.World.Movement;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Network;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Communication.Outgoing.World.Movement
{
    public class PSMovement : ServerPacket
    {
        public PSMovement(Opcodes opcode, Character character, PCMoveInfo moveinfo) : base(opcode)
        {
            byte[] packedGUID = PSUpdateObject.GenerateGuidBytes((ulong)character.GUID);
            PSUpdateObject.WriteBytes(this, packedGUID);
            Write((UInt32)moveinfo.moveFlags);
            Write((UInt32)1); // Time
            Write(moveinfo.X);
            Write(moveinfo.Y);
            Write(moveinfo.Z);
            Write(moveinfo.R);
            Write((UInt32)0); // ?
        }
    }
}
