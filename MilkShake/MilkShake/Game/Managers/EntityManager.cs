using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Tools.Database.Tables;
using Milkshake.Net;
using Milkshake.Tools.Database;
using Milkshake.Tools.Database.Helpers;
using System.Collections.Generic;
using System;

namespace Milkshake.Game.Managers
{
    public class EntityManager
    {
        public static void Boot()
        {
            
        }

        public static void SpawnPlayer(Character character)
        {
            WorldServer.Sessions.FindAll(s => s.Character != character).ForEach(s =>
            {
                s.sendMessage("Spawning: " + character.Name);
                s.sendPacket(PSUpdateObject.CreateCharacterUpdate(character));
            });
        }

        public static void SendPlayers(WorldSession session)
        {
            WorldServer.Sessions.FindAll(s => s.Character != null).FindAll(s => s.Character != session.Character).ForEach(s =>
            {
                session.sendMessage("Spawning: " + s.Character);
                session.sendPacket(PSUpdateObject.CreateCharacterUpdate(s.Character));
            });
        }

        public static void SpawnGameObjects(WorldSession worldSession)
        {
            worldSession.Entity.X = worldSession.Character.X;
            worldSession.Entity.Y = worldSession.Character.Y;
            worldSession.Entity.Z = worldSession.Character.Z;

            DateTime before = DateTime.Now;
            List<GameObject> gameObjects = DBGameObject.GetGameObjects(worldSession.Entity, 1000);
            int mills = DateTime.Now.Subtract(before).Milliseconds;

            worldSession.sendMessage("Found: " + gameObjects.Count + " in " + mills);

            foreach (GameObject gameObject in gameObjects)
	        {
		        GameObjectTemplate template = DBGameObject.GetGameObjectTemplate((uint)gameObject.ID);

                if (template != null)
                {
                    worldSession.sendPacket(PSUpdateObject.CreateGameObject(gameObject.X, gameObject.Y, gameObject.Z, gameObject, template));
                }
	        }

            
        }
    }
}
