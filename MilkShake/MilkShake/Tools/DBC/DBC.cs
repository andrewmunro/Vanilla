using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Game.Constants.Game.World.Item;
using Milkshake.Tools.Config;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools.Database.Tables;
using SQLite;
using System.Diagnostics;
using Milkshake.Tools.DBC.Helper;

namespace Milkshake.Tools.DBC
{
    public class DBC
    {
        public static SQLiteConnection SQLite { get; private set; }

        // [Helper]
        public static SpellsDBC Spells { get; private set; }
        public static ItemTemplaceDBC ItemTemplates { get; private set; }
        public static ChrStartingOutfitDBC ChrStartingOutfit { get; private set; }

        // [Non-Helper]
        public static CachedDBC<ChrRacesEntry> ChrRaces { get; private set; }
        public static CachedDBC<AreaTableEntry> AreaTables { get; private set; }
        public static CachedDBC<AreaTriggerEntry> AreaTriggers { get; private set; }

        public static void Boot()
        {
            SQLite = new SQLiteConnection(INI.GetValue(ConfigValues.DB, ConfigValues.DBC));

            Spells = new SpellsDBC();
            ItemTemplates = new ItemTemplaceDBC();
            ChrStartingOutfit = new ChrStartingOutfitDBC();

            ChrRaces = new CachedDBC<ChrRacesEntry>();
            AreaTables = new CachedDBC<AreaTableEntry>();
            AreaTriggers = new CachedDBC<AreaTriggerEntry>();
        }
    }
}
