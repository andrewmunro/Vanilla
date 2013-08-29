using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Entitys;
using Milkshake.Communication.Outgoing.World.Update;
using System.Threading;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.Database;
using Milkshake.Tools;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Network;

namespace Milkshake.Game.Managers
{
    public class WorldManager
    {
        public WorldManager()
        {
            new Thread(UpdateThread).Start();
        }

        private void UpdateThread()
        {
            while (true)
            {
                Update();
                Thread.Sleep(500);
            }
        }

        public void Update()
        {
            foreach (PlayerEntity player in PlayerManager.Players)
            {
                // Move this somewhere else?
                if (player.OutOfRangeEntitys.Any() || player.UpdateBlocks.Any())
                {
                    List<UpdateBlock> UpdateBlocks = new List<UpdateBlock>();

                    if (player.OutOfRangeEntitys.Any())
                    {
                        UpdateBlocks.Add(new OutOfRangeBlock(player.OutOfRangeEntitys));
                    }

                    if (player.UpdateBlocks.Any())
                    {
                        lock (UpdateBlocks)
                        {
                            lock (player.UpdateBlocks)
                            {
                                UpdateBlocks.AddRange(player.UpdateBlocks);
                            }
                        }
                    }

                    player.Session.sendPacket(new PSUpdateObject(UpdateBlocks));

                    player.OutOfRangeEntitys.Clear();
                    player.UpdateBlocks.Clear();

                    // [Debug]
                    //player.Session.sendMessage("-- Update Packet --");
                    //UpdateBlocks.ForEach(ub => player.Session.sendMessage(ub.Info));
                    //player.Session.sendMessage(" ");
                }
            }
        }

    }

    public interface ILocation
    {
        //float X { get; set; }
    }

    public abstract class EntityComponent<T> where T : Entitys.EntityBase //, ILocation - later...
    {
        public List<T> Entitys = new List<T>();

        public EntityComponent()
        {
            Entitys = new List<T>();

            new Thread(UpdateThread).Start();

            World.OnPlayerSpawn += World_OnPlayerSpawn;
        }

        private void World_OnPlayerSpawn(PlayerEntity player)
        {
            GenerateEntitysForPlayer(player);
        }

        private void UpdateThread()
        {
            while (true)
            {
                Update();
                Thread.Sleep(500);
            }
        }

        public virtual void Update()
        {
            // Spawning && Despawning
            foreach (PlayerEntity player in PlayerManager.Players)
            {
                foreach (T entity in Entitys.ToArray())
                {
                    if (InRange(player, entity, 50))
                    {
                        if (!PlayerKnowsEntity(player, entity))
                        {
                            SpawnEntityForPlayer(player, entity);
                        }
                    }
                    
                    if (!InRange(player, entity, 100) && PlayerKnowsEntity(player, entity))
                    {
                        DespawnEntityForPlayer(player, entity);
                    }
                }
            }

        }

        private bool Contains(T entity)
        {
            return Entitys.FindAll(e => (e as ObjectEntity).ObjectGUID.RawGUID == (entity as ObjectEntity).ObjectGUID.RawGUID).Any();
        }

        public virtual void AddEntityToWorld(T entity)
        {
            if(!Contains(entity))
            {
                Entitys.Add(entity);
            }
        }

        public virtual void RemoveEntityFromWorld(T entity)
        {
            Entitys.Remove(entity);

            PlayersWhoKnow(entity).ForEach(p => DespawnEntityForPlayer(p, entity));
        }

        public virtual void SpawnEntityForPlayer(PlayerEntity player, T entity)
        {
            EntityListFromPlayer(player).Add(entity);
        }

        public virtual void DespawnEntityForPlayer(PlayerEntity player, T entity)
        {
            EntityListFromPlayer(player).Remove(entity);

            player.OutOfRangeEntitys.Add((entity as ObjectEntity));
        }

        public List<PlayerEntity> PlayersWhoKnow(T entity)
        {
            return PlayerManager.Players.FindAll(p => EntityListFromPlayer(p).Contains(entity));
        }

        public bool PlayerKnowsEntity(PlayerEntity player, T entity)
        {
            return EntityListFromPlayer(player).Contains(entity);
        }

        public abstract void GenerateEntitysForPlayer(PlayerEntity player);
        public abstract bool InRange(PlayerEntity player, T entity, float range);
        public abstract List<T> EntityListFromPlayer(PlayerEntity player);
    }

    public class GameObjectManager : EntityComponent<GOEntity>
    {
        public override void GenerateEntitysForPlayer(PlayerEntity player)
        {
            List<GameObject> gameObjects = DBGameObject.GetGameObjects(player, 100);

            gameObjects.ForEach(closeGO =>
            {
                GameObjectTemplate template = DBGameObject.GetGameObjectTemplate((uint)closeGO.ID);
                
                if (template != null)
                {
                    AddEntityToWorld(new GOEntity(closeGO, template));
                }
            });
        }

        public override void SpawnEntityForPlayer(PlayerEntity player, GOEntity entity)
        {
            lock (player.UpdateBlocks)
            {
                player.UpdateBlocks.Add(new CreateGOBlock(entity));
            }

            base.SpawnEntityForPlayer(player, entity);
        }

        public override List<GOEntity> EntityListFromPlayer(PlayerEntity player)
        {
            return player.KnownGameObjects;
        }

        public override bool InRange(PlayerEntity player, GOEntity entity, float range)
        {
            double distance = GetDistance(player.X, player.Y, entity.GameObject.X, entity.GameObject.Y);

            return distance < range;
        }

        private static double GetDistance(float aX, float aY, float bX, float bY)
        {
            double a = aX - bX;
            double b = bY - aY;

            return Math.Sqrt(a * a + b * b);
        }
    }

    public class UnitComponent : EntityComponent<UnitEntity>
    {
        public override void GenerateEntitysForPlayer(PlayerEntity player)
        {
            List<CreatureEntry> allUnits = DB.World.Table<CreatureEntry>().ToList();

            List<CreatureEntry> unitsClose = allUnits
                .FindAll(m => m.map == player.Character.MapID)
                .FindAll(m => Helper.Distance(m.position_x, m.position_y, player.Character.X, player.Character.Y) < 500);   

            unitsClose.ForEach(closeUnit => AddEntityToWorld(new UnitEntity(closeUnit)));
        }

        public override void SpawnEntityForPlayer(PlayerEntity player, UnitEntity entity)
        {
            lock (player.UpdateBlocks)
            {
				// We need to create a new UnitEntity to push all the UpdateData
                player.UpdateBlocks.Add(new CreateUnitBlock(entity));
            }
            base.SpawnEntityForPlayer(player, entity);
        }

		public override void Update()
		{
			base.Update();


			foreach (UnitEntity entity in Entitys.ToArray().ToList())
			{
			    List<PlayerEntity> playersWhoKnowEntity = PlayersWhoKnow(entity);

                if (entity.UpdateCount > 0 && playersWhoKnowEntity.Count > 0)
				{
					// Generate update packet
					ServerPacket packet = PSUpdateObject.UpdateValues(entity);
					playersWhoKnowEntity.ForEach(e => e.Session.sendPacket(packet));
				}
			}
		}

        public override List<UnitEntity> EntityListFromPlayer(PlayerEntity player)
        {
            return player.KnownUnits;
        }

        public override bool InRange(PlayerEntity player, UnitEntity entity, float range)
        {
            double distance = GetDistance(player.X, player.Y, entity.X, entity.Y);

            return distance < range;
        }

        private static double GetDistance(float aX, float aY, float bX, float bY)
        {
            double a = aX - bX;
            double b = bY - aY;

            return Math.Sqrt(a * a + b * b);
        }
    }
}
