using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Tools.Database.Helpers
{
    public class DBAreaTriggers
    {
        private static List<AreaTriggerTeleport> AreaTriggerTeleportCache;
        public static List<AreaTriggerTeleport> AreaTriggerTeleport
        {
            get
            {
                if (AreaTriggerTeleportCache == null) AreaTriggerTeleportCache = DB.SQLite.Table<AreaTriggerTeleport>().ToList();

                return AreaTriggerTeleportCache;
            }
        }
    }
}
