using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Entitys;

namespace Milkshake.Game
{
    public delegate void PlayerEvent(PlayerEntity player);

    // Temp name...
    public class World
    {
        public static event PlayerEvent OnPlayerSpawn;
        public static event PlayerEvent OnPlayerDespawn;

        public static void DispatchOnPlayerSpawn(PlayerEntity player)
        {
            if (OnPlayerSpawn != null) OnPlayerSpawn(player);
        }

        public static void DispatchOnPlayerDespawn(PlayerEntity player)
        {
            if (OnPlayerDespawn != null) OnPlayerDespawn(player);
        }
    }
}
