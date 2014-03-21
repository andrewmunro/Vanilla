using Vanilla.World.Database;

namespace Vanilla.World.Components.Entity
{
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.IO;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object.Creature;
    using Vanilla.World.Game.Entity.Object.GameObject;
    using Vanilla.World.Game.Entity.Object.Player;

    public class EntityChunk
    {
        private readonly VanillaWorld vanillaWorld;

        public Vector2 ChunkLocation { get; set; }

        private EntityBounds bounds;

        public List<PlayerEntity> PlayerEntities = new List<PlayerEntity>();
        public List<CreatureEntity> CreatureEntities = new List<CreatureEntity>();
        public List<GameObjectEntity> GameObjectEntities = new List<GameObjectEntity>();

        private IRepository<creature> CreatureDatabase { get { return vanillaWorld.WorldDatabase.GetRepository<creature>(); } }
        private IRepository<creature_template> CreatureTemplateDatabase { get { return vanillaWorld.WorldDatabase.GetRepository<creature_template>(); } }
        private IRepository<gameobject> GameObjectDatabase { get { return vanillaWorld.WorldDatabase.GetRepository<gameobject>(); } }

        public EntityChunk(Vector2 chunkLocation, float chunkSize, VanillaWorld vanillaWorld)
        {
            this.vanillaWorld = vanillaWorld;
            this.ChunkLocation = chunkLocation;

            this.bounds = new EntityBounds
                         {
                             MinX = (chunkLocation.X * chunkSize),
                             MinY = (chunkLocation.Y * chunkSize),
                             MaxX = ((chunkLocation.X + 1) * chunkSize),
                             MaxY = ((chunkLocation.Y + 1) * chunkSize)
                         };

            AddInitialEntities();
        }

        public List<ISubscribable> GetChunkEntitiesExceptSelf(PlayerEntity player)
        {
            var entities = new List<ISubscribable>();
            entities.AddRange(PlayerEntities.Where(pe => pe.ObjectGUID.RawGUID != player.ObjectGUID.RawGUID));
            entities.AddRange(CreatureEntities);
            entities.AddRange(GameObjectEntities);
            return entities;
        }

        private void AddInitialEntities()
        {
            CreatureDatabase.Where(
                c =>
                c.position_x > this.bounds.MinX && c.position_y > this.bounds.MinY && c.position_x < this.bounds.MaxX
                && c.position_y < this.bounds.MaxY).ToList().ForEach(this.AddCreatureEntity);

            GameObjectDatabase.Where(
                c =>
                c.position_x > this.bounds.MinX && c.position_y > this.bounds.MinY && c.position_x < this.bounds.MaxX
                && c.position_y < this.bounds.MaxY).ToList().ForEach(this.AddGameObjectEntity);
        }

        public void AddCreatureEntity(creature creature)
        {
            creature_template template = CreatureTemplateDatabase.SingleOrDefault(ct => ct.entry == creature.id);
            ObjectGUID guid = new ObjectGUID((ulong)creature.guid, TypeID.TYPEID_UNIT); //right type?
            CreatureEntity creatureEntity = new CreatureEntity(guid, creature, template);
            CreatureEntities.Add(creatureEntity);
            creatureEntity.Setup();
        }

        public void AddGameObjectEntity(gameobject gameObject)
        {
            ObjectGUID guid = new ObjectGUID((ulong)gameObject.guid, TypeID.TYPEID_GAMEOBJECT); //right type?
            gameobject_template template = vanillaWorld.WorldDatabase.GetRepository<gameobject_template>().SingleOrDefault(t => t.entry == gameObject.id);
            GameObjectEntity gameObjectEntity = new GameObjectEntity(guid, gameObject, template);
            GameObjectEntities.Add(gameObjectEntity);
            gameObjectEntity.Setup();
        }

        public void RemovePlayerEntity(PlayerEntity player)
        {
            PlayerEntities.Remove(player);
        }
    }
}
