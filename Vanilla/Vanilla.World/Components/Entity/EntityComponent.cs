using System;
using System.Collections.Generic;

namespace Vanilla.World.Components.Entity
{
    using System.Net;

    using Vanilla.Database.Character.Models;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object.Player;
    using Vanilla.World.Network;

    public class EntityComponent : WorldServerComponent
    {
        public Dictionary<Vector2, EntityChunk> EntityChunks;

        public List<PlayerEntity> PlayerEntities; 

        public const int ChunkViewDistance = 1;

        public const float ChunkSize = 100f;

        public EntityComponent(VanillaWorld vanillaWorld)
            : base(vanillaWorld)
        {
            EntityChunks = new Dictionary<Vector2, EntityChunk>();
            PlayerEntities = new List<PlayerEntity>();
        }

        public void Update()
        {
            PlayerEntities.ForEach(this.UpdateSessionChunk);
        }

        public PlayerEntity AddPlayerEntity(Character character, WorldSession session)
        {
            ObjectGUID guid = new ObjectGUID((ulong)character.GUID, (TypeID)25);
            PlayerEntity playerEntity = new PlayerEntity(guid, character, session);
            PlayerEntities.Add(playerEntity);
            playerEntity.Setup();
            return playerEntity;
        }

        private void UpdateSessionChunk(PlayerEntity player)
        {
            if (player.Location.Moved == false) return;
            var chunkX = (int)Math.Floor(player.Location.X / ChunkSize);
            var chunkY = (int)Math.Floor(player.Location.Y / ChunkSize);

            var chunkLocation = new Vector2(chunkX, chunkY);

            if (player.CurrentChunk != null)
            {
                //If chunk current chunk has not changed, no need to update.
                if (player.CurrentChunk.ChunkLocation.Equals(chunkLocation)) return;
                //If has changedChunk, remove player entity from old chunk
                player.CurrentChunk.RemovePlayerEntity(player);
            }

            //Initialises chunks if they don't exist
            player.SubscribedChunks = GetChunkAndSurroundings(chunkLocation);

            //Add Player to chunk
            this.AddPlayerToChunk(player, EntityChunks[chunkLocation]);
        }

        private void AddPlayerToChunk(PlayerEntity player, EntityChunk entityChunk)
        {
            player.CurrentChunk = entityChunk;
            if (!entityChunk.PlayerEntities.Contains(player)) entityChunk.PlayerEntities.Add(player);
        }

        private List<EntityChunk> GetChunkAndSurroundings(Vector2 chunkLocation)
        {
            var chunks = new List<EntityChunk>();

            for (int i = (int)chunkLocation.X - ChunkViewDistance; i < (int)chunkLocation.X + ChunkViewDistance + 1; i++)
            {
                for (int j = (int)chunkLocation.Y - ChunkViewDistance; j < (int)chunkLocation.Y + ChunkViewDistance + 1; j++)
                {
                    chunks.Add(CreateChunkIfNotExists(new Vector2(i, j)));
                }
            }
            return chunks;
        }

        private EntityChunk CreateChunkIfNotExists(Vector2 chunkLocation)
        {
            if (!EntityChunks.ContainsKey(chunkLocation))
            {
                var chunk = new EntityChunk(chunkLocation, ChunkSize, Core);
                EntityChunks[chunkLocation] = chunk;
                return chunk;
            }
            return EntityChunks[chunkLocation];
        }

        public void RemovePlayerEntity(PlayerEntity player)
        {
            player.CurrentChunk.RemovePlayerEntity(player);
            PlayerEntities.Remove(player);
        }
    }
}
