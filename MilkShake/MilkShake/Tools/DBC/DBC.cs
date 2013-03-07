using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.DBC.Tables;
using SQLite;

namespace Milkshake.Tools.DBC
{
    public class DBC
    {
        private static SQLiteConnection SQLite;

        public static void Boot()
        {
            SQLite = new SQLiteConnection("dbc.db3");
        }

        public static TableQuery<ChrRacesEntry> ChrRaces
        {
            get { return SQLite.Table<ChrRacesEntry>(); }
        }

        public static TableQuery<AreaTableEntry> AreaTable
        {
            get { return SQLite.Table<AreaTableEntry>(); }
        }

        public static TableQuery<AreaTriggerEntry> AreaTriggers
        {
            get { return SQLite.Table<AreaTriggerEntry>(); }
        }

        public static TableQuery<SpellEntry> Spells
        {
            get { return SQLite.Table<SpellEntry>(); }
        }
    }
}
