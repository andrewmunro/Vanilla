using System.Collections.Generic;
using System.Linq;
using Vanilla.World.Communication.Incoming.World.GameObject;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Game.Constants.Game.Update;
using Vanilla.World.Game.Constants.Game.World.Entity;
using Vanilla.World.Game.Entitys;
using Vanilla.World.Game.Handlers;

namespace Vanilla.World.Game.Managers
{
    public delegate void ProcessGameObjectUseCallback(WorldSession Session, GOEntity gameObject);

    public class GameObjectManager
    {
        public static Dictionary<GameObjectTypes, ProcessGameObjectUseCallback> GameObjectUseHandlers;

        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCGameObjectUse>(WorldOpcodes.CMSG_GAMEOBJ_USE, OnGameObjectUsePacket);
            GameObjectUseHandlers = new Dictionary<GameObjectTypes, ProcessGameObjectUseCallback>();

            GameObjectUseHandlers.Add(GameObjectTypes.GAMEOBJECT_TYPE_CHAIR, OnUseChair);
        }

        private static void OnGameObjectUsePacket(WorldSession session, PCGameObjectUse packet)
        {
            GOEntity gameObject = VanillaWorld.GameObjectComponent.Entitys.First(go => go.GUID == packet.GUID);

            GameObjectTemplate template = gameObject.GameObjectTemplate;

            if (gameObject != null && GameObjectUseHandlers.ContainsKey((GameObjectTypes)template.Type))
            {
                GameObjectUseHandlers[(GameObjectTypes)template.Type](session, gameObject);
            }
        }

        private static void OnUseChair(WorldSession session, GOEntity gameObject)
        {
            GameObject go = gameObject.GameObject;

            session.Entity.TeleportTo(session.Character.MapID, go.X, go.Y, go.Z);
            session.Entity.SetStandState(UnitStandStateType.UNIT_STAND_STATE_SIT_CHAIR);
        }
    }
}
