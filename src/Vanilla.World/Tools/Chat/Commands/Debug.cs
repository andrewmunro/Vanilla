using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Net;
using Milkshake.Game.Entitys;
using Milkshake.Network;
using Milkshake.Communication;
using Milkshake.Tools.Extensions;

namespace Milkshake.Tools.Chat.Commands
{
    [ChatCommandNode("debug", "Debug Commands")]
    public class Debug
    {
        [ChatCommand("come", "Makes NPC come to you!!")]
        public static void Send(WorldSession session, string[] args)
        {
            if(session.Entity.Target != null)
            {
                //session.sendMessage("Target: " + session.Entity.Name);

                UnitEntity target = session.Entity.Target;

                ServerPacket packet = new ServerPacket(WorldOpcodes.SMSG_MONSTER_MOVE);
                packet.WritePackedUInt64(target.ObjectGUID.RawGUID);
                packet.Write(target.X);
                packet.Write(target.Y);
                packet.Write(target.Z);
                packet.Write((UInt32)Environment.TickCount);
                packet.Write((byte)0); // SPLINETYPE_NORMAL
                packet.Write(0); // sPLINE FLAG
                packet.Write(100); // TIME
                packet.Write(1);
                packet.Write(session.Character.X);
                packet.Write(session.Character.Y);
                packet.Write(session.Character.Z);

                session.sendPacket(packet);



            }
        }
    }
}
