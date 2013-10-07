using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Tools.Database.Tables;
using Milkshake.Game.Entitys;

namespace Milkshake.Communication.Outgoing.World.Movement
{
    public class PSMoveKnockBack : ServerPacket
    {
        public PSMoveKnockBack(PlayerEntity player, float vcos, float vsin, float horizontalSpeed, float verticalSpeed) : base(WorldOpcodes.SMSG_MOVE_KNOCK_BACK)
        {
            byte[] packedGUID = PSUpdateObject.GenerateGuidBytes(player.ObjectGUID.RawGUID);
            PSUpdateObject.WriteBytes(this, packedGUID);
            Write((UInt32)0); // Sequence
            Write((float)vcos); 
            Write((float)vsin);
            Write((float)horizontalSpeed);
            Write((float)verticalSpeed);
        }
    }
}
