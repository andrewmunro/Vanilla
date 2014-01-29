namespace Vanilla.World.Components.Entity
{
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.IO;
    using Vanilla.Core.Logging;
    using Vanilla.Database.World.Models;
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

        private IRepository<Creature> CreatureDatabase { get { return vanillaWorld.WorldDatabase.GetRepository<Creature>(); } }
        private IRepository<CreatureTemplate> CreatureTemplateDatabase { get { return vanillaWorld.WorldDatabase.GetRepository<CreatureTemplate>(); } }
        private IRepository<GameObject> GameObjectDatabase { get { return vanillaWorld.WorldDatabase.GetRepository<GameObject>(); } }

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
            //TODO Enable GameObjectEntities when updateBuilder is done.
            //entities.AddRange(GameObjectEntities);
            return entities;
        }

        private void AddInitialEntities()
        {
            CreatureDatabase.Where(
                c =>
                c.PositionX > this.bounds.MinX && c.PositionY > this.bounds.MinY && c.PositionX < this.bounds.MaxX
                && c.PositionY < this.bounds.MaxY).ToList().ForEach(c=> this.AddCreatureEntity(c));

            GameObjectDatabase.Where(
                c =>
                c.PositionX > this.bounds.MinX && c.PositionY > this.bounds.MinY && c.PositionX < this.bounds.MaxX
                && c.PositionY < this.bounds.MaxY).ToList().ForEach(g => this.AddGameObjectEntity(g));
        }

        public CreatureEntity AddCreatureEntity(Creature creature)
        {
            CreatureTemplate template = CreatureTemplateDatabase.SingleOrDefault(ct => ct.Entry == creature.ID);
            ObjectGUID guid = new ObjectGUID((ulong)creature.GUID, (TypeID)template.Type); //right type?
            CreatureEntity creatureEntity = new CreatureEntity(guid, creature, template);
            CreatureEntities.Add(creatureEntity);
            creatureEntity.Setup();
            return creatureEntity;
        }

        public GameObjectEntity AddGameObjectEntity(GameObject gameObject)
        {
            ObjectGUID guid = new ObjectGUID((ulong)gameObject.GUID, (TypeID)21); //right type?
            GameObjectTemplate template = vanillaWorld.WorldDatabase.GetRepository<GameObjectTemplate>().SingleOrDefault(t => t.Entry == gameObject.GUID);
            GameObjectEntity gameObjectEntity = new GameObjectEntity(guid, gameObject, template);
            GameObjectEntities.Add(gameObjectEntity);
            gameObjectEntity.Setup();
            return gameObjectEntity;
        }

        public void RemovePlayerEntity(PlayerEntity player)
        {
            PlayerEntities.Remove(player);
        }
    }
}
