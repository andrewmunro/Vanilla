using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Entitys;
using System.Threading;
using Milkshake.Communication.Outgoing.World.Update;

namespace Milkshake.Game.Managers
{
    public class PlayerManager
    {
        public List<PlayerEntity> Players { get; private set; }

        public PlayerManager()
        {
            Players = new List<PlayerEntity>();

            World.OnPlayerSpawn += new PlayerEvent(OnPlayerSpawn);
            World.OnPlayerDespawn += new PlayerEvent(OnPlayerDespawn);

            new Thread(Update).Start();
        }

        private void OnPlayerDespawn(PlayerEntity player)
        {
            foreach (PlayerEntity remotePlayer in Players)
            {
                // Skip own player
                if (player != remotePlayer) continue;

                if (remotePlayer.KnownPlayers.Contains(player))
                {
                    DespawnPlayer(remotePlayer, player);
                }
            }

            Players.Remove(player);
        }

        private void OnPlayerSpawn(PlayerEntity player)
        {
            // Player Requesting Spawn
            Players.Add(player);
        }

        private void Update()
        {
            while (true)
            {


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

                Thread.Sleep(100);
            }
        }

        private void SpawnPlayer(PlayerEntity remote, PlayerEntity player)
        {
            // Should be sending player entity
            remote.Session.sendPacket(PSUpdateObject.CreateCharacterUpdate(player.Character));

            // Add it to known players
            remote.KnownPlayers.Add(player);

            remote.Session.sendMessage("SpawningPlayer: " + player.Character.Name);
        }

        private void DespawnPlayer(PlayerEntity remote, PlayerEntity player)
        {
            List<ObjectEntity> despawnPlayer = new List<ObjectEntity>();
            despawnPlayer.Add(player);

            // Should be sending player entity
            remote.Session.sendPacket(PSUpdateObject.CreateOutOfRangeUpdate(despawnPlayer));

            // Add it to known players
            remote.KnownPlayers.Remove(player);

            remote.Session.sendMessage("DespawningPlayer: " + player.Character.Name);
        }

        private bool InRangeCheck(PlayerEntity playerA, PlayerEntity playerB)
        {
            // Check map
            // Check distance

            double distance = GetDistance(playerA.X, playerA.Y, playerB.X, playerB.Y);

            return  distance < 50;
        }

        private static double GetDistance(float aX, float aY, float bX, float bY)
        {
            //pythagorean theorem c^2 = a^2 + b^2
            //thus c = square root(a^2 + b^2)
            double a = (double)(aX - bX);
            double b = (double)(bY - aY);

            return Math.Sqrt(a * a + b * b);
        }
    }
}
