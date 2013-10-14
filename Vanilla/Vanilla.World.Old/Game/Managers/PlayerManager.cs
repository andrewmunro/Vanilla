using System;
using System.Collections.Generic;
using System.Threading;
using Vanilla.World.Communication.Outgoing.World.Update;
using Vanilla.World.Game.Entitys;
using Vanilla.World.Network;

namespace Vanilla.World.Game.Managers
{
    public class PlayerManager
    {
        public static List<PlayerEntity> Players { get; private set; }

        public static void Boot()
        {
            Players = new List<PlayerEntity>();

            World.OnPlayerSpawn += new PlayerEvent(OnPlayerSpawn);
            World.OnPlayerDespawn += new PlayerEvent(OnPlayerDespawn);

            new Thread(Update).Start();
        }

        private static void OnPlayerDespawn(PlayerEntity player)
        {
            foreach (PlayerEntity remotePlayer in Players)
            {
                // Skip own player
                if (player == remotePlayer) continue;

                if (remotePlayer.KnownPlayers.Contains(player))
                {
                    DespawnPlayer(remotePlayer, player);
                }
            }

            Players.Remove(player);
        }

        private static void OnPlayerSpawn(PlayerEntity player)
        {
            // Player Requesting Spawn
            Players.Add(player);
        }

        private static void Update()
        {
            while (true)
            {
                // Spawning && Despawning
                foreach (PlayerEntity player in Players)
                {
                    foreach (PlayerEntity otherPlayer in Players)
                    {
                        // Ignore self
                        if(player == otherPlayer) continue;

                        if (InRangeCheck(player, otherPlayer))
                        {
                            if (!player.KnownPlayers.Contains(otherPlayer))
                            {
                                SpawnPlayer(player, otherPlayer);
                            }
                        }
                        else
                        {
                            if (player.KnownPlayers.Contains(otherPlayer))
                            {
                                DespawnPlayer(player, otherPlayer);
                            }
                        }
                    }
                }

                // Update (Maybe have one for all entitys (GO, Unit & Players)
                foreach (PlayerEntity player in Players)
                {
                    if (player.UpdateCount > 0)
                    {
                        // Generate update packet
                        ServerPacket packet = PSUpdateObject.UpdateValues(player);

                        player.Session.sendPacket(packet);
                        World.SessionsWhoKnow(player).ForEach(s => s.SendPacket(packet));
                    }
                }

                Thread.Sleep(100);
            }
        }

        private static void SpawnPlayer(PlayerEntity remote, PlayerEntity player)
        {
            // Should be sending player entity
            remote.Session.sendPacket(PSUpdateObject.CreateCharacterUpdate(player.Character));

            // Add it to known players
            remote.KnownPlayers.Add(player);

            remote.Session.sendMessage("SpawningPlayer: " + player.Character.Name);
        }

        private static void DespawnPlayer(PlayerEntity remote, PlayerEntity player)
        {
            List<ObjectEntity> despawnPlayer = new List<ObjectEntity>();
            despawnPlayer.Add(player);

            // Should be sending player entity
            remote.Session.sendPacket(PSUpdateObject.CreateOutOfRangeUpdate(despawnPlayer));

            // Add it to known players
            remote.KnownPlayers.Remove(player);

            remote.Session.sendMessage("DespawningPlayer: " + player.Character.Name);
        }

        private static bool InRangeCheck(PlayerEntity playerA, PlayerEntity playerB)
        {
            // Check map
            // Check distance

            double distance = GetDistance(playerA.X, playerA.Y, playerB.X, playerB.Y);

            return  distance < 50;
        }

        private static double GetDistance(float aX, float aY, float bX, float bY)
        {
            double a = (double)(aX - bX);
            double b = (double)(bY - aY);

            return Math.Sqrt(a * a + b * b);
        }
    }
}
