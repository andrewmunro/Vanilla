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

namespace Milkshake.Game.Managers
{
    public class WorldManager
    {

    }

    public interface ILocation
    {
        //float X { get; set; }
    }

    public abstract class EntityComponent<T> where T : Entitys.EntityBase, ILocation
    {
        public List<T> Entitys = new List<T>();

        public EntityComponent()
        {
            Entitys = new List<T>();

            new Thread(UpdateThread).Start();

            World.OnPlayerSpawn += new PlayerEvent(World_OnPlayerSpawn);
        }

        void World_OnPlayerSpawn(PlayerEntity player)
        {
            GenerateEntitysForPlayer(player);
        }

        private void UpdateThread()
        {
            while (true)
            {
                Update();
                Thread.Sleep(100);
            }
        }

        public virtual void Update()
        {
            // Spawning && Despawning
            foreach (PlayerEntity player in PlayerManager.Players)
            {
                foreach (T entity in Entitys.ToArray())
                {
                    if (InRange(player, entity))
                    {
                        if (!PlayerKnowsEntity(player, entity))
                        {
                            SpawnEntityForPlayer(player, entity);
                        }
                    }
                    else
                    {
                        if (PlayerKnowsEntity(player, entity))
                        {
                            DespawnEntityForPlayer(player, entity);
                        }
                    }
                }
            }
        }

        public virtual void SpawnEntity(T entity)
        {
            Entitys.Add(entity);
        }

        public virtual void DespawnEntity(T entity)
        {
            Entitys.Remove(entity);

            PlayersWhoKnow(entity).ForEach(p => DespawnEntityForPlayer(p, entity));
        }

        public virtual void SpawnEntityForPlayer(PlayerEntity player, T entity)
        {

        }

        public virtual void DespawnEntityForPlayer(PlayerEntity player, T entity)
        {
            player.Session.sendPacket(PSUpdateObject.CreateOutOfRangeUpdate(entity as ObjectEntity));
        }

        public virtual void GenerateEntitysForPlayer(PlayerEntity player)
        {

        }

        public abstract List<PlayerEntity> PlayersWhoKnow(T entity);

        public abstract bool InRange(PlayerEntity player, T entity);
        public abstract bool PlayerKnowsEntity(PlayerEntity player, T entity);
    }

    public class UnitManager : EntityComponent<UnitEntity>
    {
        public override void GenerateEntitysForPlayer(PlayerEntity player)
        {
            List<CreatureEntry> allUnits = DB.World.Table<CreatureEntry>().ToList();

            List<CreatureEntry> unitsClose = allUnits
                .FindAll(m => m.map == player.Character.MapID)
                .FindAll(m => Helper.Distance(m.position_x, m.position_y, player.Character.X, player.Character.Y) < 50);

            unitsClose.ForEach(closeUnit =>
            {
                SpawnEntity(new UnitEntity(closeUnit));
            });
        }


        public override void SpawnEntityForPlayer(PlayerEntity player, UnitEntity entity)
        {
            player.KnownUnits.Add(entity);

            player.Session.sendMessage("Spawning: " + entity.Template.name);

            player.Session.sendPacket(PSUpdateObject.CreateUnitUpdate(new UnitEntity(entity.TEntry)));
        }

        public override void DespawnEntityForPlayer(PlayerEntity player, UnitEntity entity)
        {
            player.KnownUnits.Remove(entity);

            player.Session.sendMessage("Despawning: " + entity.Template.name);

            base.DespawnEntityForPlayer(player, entity);
        }

        public override List<PlayerEntity> PlayersWhoKnow(UnitEntity entity)
        {
            return World.PlayersWhoKnowUnit(entity);
        }

        public override bool InRange(PlayerEntity player, UnitEntity entity)
        {
            double distance = GetDistance(player.X, player.Y, entity.X, entity.Y);

            return distance < 50;
        }

        private static double GetDistance(float aX, float aY, float bX, float bY)
        {
            double a = (double)(aX - bX);
            double b = (double)(bY - aY);

            return Math.Sqrt(a * a + b * b);
        }

        public override bool PlayerKnowsEntity(PlayerEntity player, UnitEntity entity)
        {
            return player.KnownUnits.Contains(entity);
        }
    }
}
