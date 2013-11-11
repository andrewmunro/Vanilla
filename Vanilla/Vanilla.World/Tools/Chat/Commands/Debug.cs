/*
using System;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Game.Entitys;
using Vanilla.World.Network;

namespace Vanilla.World.Tools.Chat.Commands
{
    using Vanilla.Core.Opcodes;

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

                session.SendPacket(packet);



            }
        }
    }
}
*/
