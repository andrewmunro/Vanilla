using System.Linq;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Communication.Outgoing.World.Entity;
using Vanilla.World.Game.Entitys;
using Vanilla.World.Game.Handlers;
using Vanilla.World.Network;

namespace Vanilla.World.Game.Managers
{
    using Vanilla.Core.Opcodes;

    public class UnitManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PacketReader>(WorldOpcodes.CMSG_ATTACKSWING, OnAttackSwing);
            WorldDataRouter.AddHandler<PacketReader>(WorldOpcodes.CMSG_CREATURE_QUERY, OnCreatureQuery);
        }

        private static void OnCreatureQuery(WorldSession session, PacketReader handler)
        {
            uint entry = handler.ReadUInt32();
            ulong GUID = handler.ReadUInt64();

            UnitEntity entity = VanillaWorld.UnitComponent.Entitys.FindAll(u => u.ObjectGUID.RawGUID == GUID).First();

            session.SendPacket(new PSCreatureQueryResponse(entry, entity));
        }

        private static void OnAttackSwing(WorldSession session, PacketReader handler)
        {
			ulong GUID = handler.ReadUInt64();

			UnitEntity target = VanillaWorld.UnitComponent.Entitys.FindAll(u => u.ObjectGUID.RawGUID == GUID).First();

			if (target != null)
            {
				session.sendMessage("Attacking:" + target.Name);

                ServerPacket packet = new ServerPacket(WorldOpcodes.SMSG_ATTACKSTART);
                packet.Write(session.Entity.ObjectGUID.RawGUID);
				packet.Write(target.ObjectGUID.RawGUID);

                session.SendPacket(packet);
            }
            else
            {
                session.sendMessage("Cant find");
            }
        }
    }
}
