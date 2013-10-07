using System;
using System.IO;
using Vanilla.World.Communication.Incoming.World.Movement;
using Vanilla.World.Communication.Outgoing.World.Update;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Movement
{
    public class PSMovement : ServerPacket
    {
        public PSMovement(WorldOpcodes worldOpcode, WorldSession session, PCMoveInfo moveinfo) : base(worldOpcode)
        {
            uint correctedMoveTime = (uint)Environment.TickCount;

            byte[] packedGUID = PSUpdateObject.GenerateGuidBytes((ulong)session.Character.GUID);
            PSUpdateObject.WriteBytes(this, packedGUID);
            PSUpdateObject.WriteBytes(this, (moveinfo.BaseStream as MemoryStream).ToArray());

            // We then overwrite the original moveTime (sent from the client) with ours
            (BaseStream as MemoryStream).Position = 4 + packedGUID.Length;
            PSUpdateObject.WriteBytes(this, BitConverter.GetBytes(correctedMoveTime));

           


            
            
            /*
            Write((UInt32)moveinfo.moveFlags);
            Write((UInt32)correctedMoveTime); // Time
            Write(moveinfo.X);
            Write(moveinfo.Y);
            Write(moveinfo.Z);
            Write(moveinfo.R);
            Write((UInt32)0); // ?
            */
            //Environment.TickCount
        }
    }
}
