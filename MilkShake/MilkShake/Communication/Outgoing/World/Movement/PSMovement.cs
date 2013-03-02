using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication.Incoming.World.Movement;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Network;
using Milkshake.Tools.Database.Tables;
using System.IO;
using Milkshake.Net;

namespace Milkshake.Communication.Outgoing.World.Movement
{
    public class PSMovement : ServerPacket
    {
        public static int MOVE_TIME_MODIFIER = 0;

        public PSMovement(Opcodes opcode, WorldSession session, PCMoveInfo moveinfo) : base(opcode)
        {
            uint correctedMoveTime = 0;

            if (MOVE_TIME_MODIFIER == 1)
            {
                correctedMoveTime = (uint)Environment.TickCount;
            }

            if (MOVE_TIME_MODIFIER == 2)
            {
                correctedMoveTime = (uint)Environment.TickCount + session.Latancy;
            }

            if (MOVE_TIME_MODIFIER == 3)
            {
                correctedMoveTime = (uint)Environment.TickCount - session.Latancy;
            }

            if (MOVE_TIME_MODIFIER == 4)
            {
                correctedMoveTime = moveinfo.time;
            }

            if (MOVE_TIME_MODIFIER == 5)
            {
                correctedMoveTime = moveinfo.time + session.Latancy;
            }

            if (MOVE_TIME_MODIFIER == 6)
            {
                correctedMoveTime = moveinfo.time + session.Latancy;
            }

            if (MOVE_TIME_MODIFIER == 7)
            {
                correctedMoveTime = moveinfo.time + (session.Latancy * 800);
            }

            if (MOVE_TIME_MODIFIER == 8)
            {
                correctedMoveTime = (uint)Environment.TickCount + (session.Latancy * 800);
            }



            // +session.Latancy;

            byte[] packedGUID = PSUpdateObject.GenerateGuidBytes((ulong)session.Character.GUID);
            PSUpdateObject.WriteBytes(this, packedGUID);
            //PSUpdateObject.WriteBytes(this, (moveinfo.BaseStream as MemoryStream).ToArray());


            //byte[] bytes = BitConverter.GetBytes(correctedMoveTime);
            //Write(bytes, 4 + packedGUID.Length, bytes.Length);
            
            
            Write((UInt32)moveinfo.moveFlags);
            Write((UInt32)correctedMoveTime); // Time
            Write(moveinfo.X);
            Write(moveinfo.Y);
            Write(moveinfo.Z);
            Write(moveinfo.R);
            Write((UInt32)0); // ?

            //Environment.TickCount
        }
    }
}
