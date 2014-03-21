using Vanilla.World.Database;

namespace Vanilla.World.Components.GameObject
{
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Entity;
    using Vanilla.World.Components.GameObject.Packets.Constants;
    using Vanilla.World.Components.GameObject.Packets.Incoming;
    using Vanilla.World.Components.GameObject.Packets.Outgoing;
    using Vanilla.World.Components.Update.Constants;
    using Vanilla.World.Game.Entity.Object.GameObject;
    using Vanilla.World.Network;

    public delegate void ProcessGameObjectUseCallback(WorldSession Session, GameObjectEntity gameObject);

    public class GameObjectComponent : WorldServerComponent
    {
        public static Dictionary<GameObjectType, ProcessGameObjectUseCallback> GameObjectUseHandlers;

        public GameObjectComponent(VanillaWorld vanillaWorld)
            : base(vanillaWorld)
        {
            Router.AddHandler<PCGameObjectUse>(WorldOpcodes.CMSG_GAMEOBJ_USE, OnGameObjectUsePacket);
            Router.AddHandler<PCGameObjectQuery>(WorldOpcodes.CMSG_GAMEOBJECT_QUERY, OnGameObjectQuery);

            GameObjectUseHandlers = new Dictionary<GameObjectType, ProcessGameObjectUseCallback>();
            GameObjectUseHandlers.Add(GameObjectType.GAMEOBJECT_TYPE_CHAIR, OnUseChair);
        }

        public void OnGameObjectQuery(WorldSession session, PCGameObjectQuery packet)
        {
            gameobject_template template = Core.WorldDatabase.GetRepository<gameobject_template>().SingleOrDefault(g => g.entry == packet.EntryID);
            session.SendPacket(new PSGameObjectQueryResponse(template));
        }

        private static void OnGameObjectUsePacket(WorldSession session, PCGameObjectUse packet)
        {
            GameObjectEntity gameObject = session.Core.GetComponent<EntityComponent>().GameObjectEntities.SingleOrDefault(g => g.ObjectGUID.RawGUID == packet.GUID);

            gameobject_template template = gameObject.Template;

            if (gameObject != null && GameObjectUseHandlers.ContainsKey((GameObjectType)template.type))
            {
                GameObjectUseHandlers[(GameObjectType)template.type](session, gameObject);
            }
        }

        private static void OnUseChair(WorldSession session, GameObjectEntity gameObjectEntity)
        {
            session.Player.TeleportTo(session.Player.Character.map, gameObjectEntity.Location.X, gameObjectEntity.Location.Y, gameObjectEntity.Location.Z, gameObjectEntity.Location.Orientation);
            session.Player.Info.StandState = (byte)UnitStandStateType.UNIT_STAND_STATE_SIT_CHAIR;
        }
    }
}
