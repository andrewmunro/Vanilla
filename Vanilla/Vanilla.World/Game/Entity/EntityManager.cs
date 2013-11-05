namespace Vanilla.World.Game.Entity
{
    using System;
    using System.Collections.Generic;

    using Vanilla.Database.Character.Models;
    using Vanilla.Database.World.Models;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object;
    using Vanilla.World.Game.Entity.Object.GameObject;
    using Vanilla.World.Game.Entity.Object.Unit.Creature;
    using Vanilla.World.Game.Entity.Object.Unit.Player;
    using Vanilla.World.Network;

    public class EntityManager
    {
        private readonly VanillaWorld vanillaWorld;

        private readonly Dictionary<ulong, PlayerEntity> playerEntities = new Dictionary<ulong, PlayerEntity>();
        private readonly Dictionary<ulong, CreatureEntity> creatureEntities = new Dictionary<ulong, CreatureEntity>();
        private readonly Dictionary<ulong, GameObjectEntity> gameObjectEntities = new Dictionary<ulong, GameObjectEntity>();

        public EntityManager(VanillaWorld vanillaWorld)
        {
            this.vanillaWorld = vanillaWorld;
        }

        public List<ObjectEntity<ObjectInfo, EntityPacketBuilder>> GetEntitiesInRadius(float x, float y, float radius)
        {
            var entities = new List<ObjectEntity<ObjectInfo, EntityPacketBuilder>>();

            foreach (KeyValuePair<ulong, PlayerEntity> entity in playerEntities)
            {
                if ((Math.Pow(x - entity.Value.Location.X, 2) + Math.Pow(y - entity.Value.Location.X, 2)) < radius * radius)
                {
                    entities.Add((ObjectEntity<ObjectInfo, EntityPacketBuilder>)entity.Value);
                }
            }

            return entities;
        }

        public GameObjectEntity AddGameObjectEntityEntity(GameObject gameObject)
        {
            ObjectGUID guid = new ObjectGUID((ulong)gameObject.GUID, (TypeID)21); //right type?
            GameObjectEntity gameObjectEntity = new GameObjectEntity(guid, gameObject);
            gameObjectEntities.Add(guid.RawGUID, gameObjectEntity);
            gameObjectEntity.Setup();
            return gameObjectEntity;
        }

        public PlayerEntity AddPlayerEntity(Character character, WorldSession session)
        {
            ObjectGUID guid = new ObjectGUID((ulong)character.GUID, (TypeID)25);
            PlayerEntity playerEntity = new PlayerEntity(guid, character, session);
            playerEntities.Add(guid.RawGUID, playerEntity);
            playerEntity.Setup();
            return playerEntity;
        }

        public void RemoveGameObjectEntity(PlayerEntity playerEntity)
        {
            RemoveGameObjectEntity(playerEntity.ObjectGUID.RawGUID);
        }

        public void RemoveGameObjectEntity(ulong guid)
        {
            gameObjectEntities.Remove(guid);
        }

        public void RemovePlayerEntity(PlayerEntity playerEntity)
        {
            RemovePlayerEntity(playerEntity.ObjectGUID.RawGUID);
        }

        public void RemovePlayerEntity(ulong guid)
        {
            playerEntities.Remove(guid);
        }

    }
}
