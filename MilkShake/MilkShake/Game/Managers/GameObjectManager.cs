using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.GameObject;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Game.Entitys;
using Milkshake.Game.Handlers;
using Milkshake.Net;
using Milkshake.Tools.Database;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Game.Managers
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
            GOEntity gameObject = MilkShake.GameObjectComponent.Entitys.First(go => go.GUID == packet.GUID);

            if (gameObject != null && GameObjectUseHandlers.ContainsKey((GameObjectTypes)gameObject.GOTypeID))
            {
                GameObjectUseHandlers[(GameObjectTypes)gameObject.GOTypeID](session, gameObject);
            }
        }

        private static void OnUseChair(WorldSession session, GOEntity gameObject)
        {
            session.Entity.TeleportTo(session.Character.MapID, gameObject.X, gameObject.Y, gameObject.Z);

        }
    }
}
