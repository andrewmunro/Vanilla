using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Entitys;
using Milkshake.Game.Managers;
using Milkshake.Net;

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

        // [Helpers]
        public static List<PlayerEntity> PlayersWhoKnow(PlayerEntity player)
        {
            return PlayerManager.Players.FindAll(p => p.KnownPlayers.Contains(player));
        }

        public static List<WorldSession> SessionsWhoKnow(PlayerEntity player, bool includeSelf = false)
        {
            List<WorldSession> sessions = PlayersWhoKnow(player).ConvertAll<WorldSession>(p => p.Session);

            if (includeSelf == true) sessions.Add(player.Session);

            return sessions;
        }


        public static List<PlayerEntity> PlayersWhoKnowUnit(UnitEntity unit)
        {
            return PlayerManager.Players.FindAll(p => p.KnownUnits.Contains(unit));
        }

/*        public static UnitEntity GetEntityByGUID(int guid)
        {
            return EntityManager.UnitManager.Entitys.FirstOrDefault(u => u.GUID == guid);
        }*/

    }
}
