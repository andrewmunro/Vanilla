using System.Collections.Generic;

namespace Vanilla.World.Tools.Database.Helpers
{
    public class DBAreaTriggers
    {
        private static List<AreaTriggerTeleport> AreaTriggerTeleportCache;
        public static List<AreaTriggerTeleport> AreaTriggerTeleport
        {
            get
            {
                if (AreaTriggerTeleportCache == null) AreaTriggerTeleportCache = DB.World.Table<AreaTriggerTeleport>().ToList();

                return AreaTriggerTeleportCache;
            }
        }
    }
}
