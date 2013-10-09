namespace Vanilla.World.Game.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Character.Database.Models;

    using Vanilla.Core;
    using Vanilla.World.Database.Models;
    using Vanilla.World.Communication.Outgoing.World.Update;
    using Vanilla.World.Game.Entitys;
    using Vanilla.World.Network;

    public class EntityManager
    {
        public static void Boot()
        {
            Thread thread = new Thread(Update);
            thread.Start();
        }

        public static void Update()
        {
            /*while (true)
            {
                /*
                foreach (ObjectEntity entity in ObjectEntity.Entitys.ToArray())
                {
                    if (entity.UpdateCount > 0)
                    {
                        ServerPacket packet = PSUpdateObject.UpdateValues(entity);

                        WorldServer.Sessions.FindAll(s => entity.ObjectGUID != null).ForEach(s => 
                            {
                                s.sendMessage("Update Packet From: " + (entity as PlayerEntity).Character.Name);
                                s.SendPacket(packet);
                            });
                    }


                    
                    if (entity is PlayerEntity)
                    {
                        PlayerEntity player = entity as PlayerEntity;

                        float distance = (float)Math.Sqrt(Math.Pow(player.X - player.lastUpdateX, 2) + Math.Pow(player.Y - player.lastUpdateY, 2));

                        if (player.Session != null && distance > 50)
                        {
                            SpawnGameObjects(player.Session);                           
                        }
                    }
                }

                */
                Thread.Sleep(100);
            
        }

        public static void SpawnPlayer(Character character)
        {
            WorldServer.Sessions.FindAll(s => s.Character != character).ForEach(s =>
            {
                s.sendMessage("Spawning: " + character.Name);
                s.SendPacket(PSUpdateObject.CreateCharacterUpdate(character));
            });
        }

        public static void SendPlayers(WorldSession session)
        {
            WorldServer.Sessions.FindAll(s => s.Character != null).FindAll(s => s.Character != session.Character).ForEach(s =>
            {
                session.sendMessage("Spawning: " + s.Character);
                session.SendPacket(PSUpdateObject.CreateCharacterUpdate(s.Character));
            });
        }

        public static void SpawnGameObjects(WorldSession worldSession)
        {
            worldSession.Entity.LastUpdateX = worldSession.Entity.X;
            worldSession.Entity.LastUpdateY = worldSession.Entity.Y;

            worldSession.Entity.X = worldSession.Character.PositionX;
            worldSession.Entity.Y = worldSession.Character.PositionY;
            worldSession.Entity.Z = worldSession.Character.PositionZ;

            DateTime before = DateTime.Now;
            List<GameObject> gameObjects = GetNearbyGameObjects(worldSession.Entity, 100);
            int mills = DateTime.Now.Subtract(before).Milliseconds;

            worldSession.sendMessage("Sending " + gameObjects.Count + " in " + mills);

            foreach (GameObject gameObject in gameObjects)
            {
                GameObjectTemplate template = VanillaWorld.WorldDatabase.GameobjectTemplates.Single(got => got.Entry == gameObject.ID);

                if (template != null)
                {
                    worldSession.SendPacket(PSUpdateObject.CreateGameObject(gameObject.PositionX, gameObject.PositionY, gameObject.PositionZ, gameObject, template));
                }
            }
        }


        private static List<GameObject> GetNearbyGameObjects(PlayerEntity entity, float Radius)
        {
            return VanillaWorld.WorldDatabase.GameObjects.Where(go => go.Map == entity.Character.Map && Utils.Distance(entity.Character.PositionX, entity.Character.PositionY, go.PositionX, go.PositionY) < Radius).ToList();
        }
    }
}
