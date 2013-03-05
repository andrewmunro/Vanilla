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
        public static SQLiteConnection SQLite;

        public static void Boot()
        {
            SQLite = new SQLiteConnection("dbc.db3");
        }
        public static TableQuery<AreaTableEntry> AreaTable
        {
            get { return SQLite.Table<AreaTableEntry>(); }
        }

        public static TableQuery<AreaTriggerEntry> AreaTrigger
        {
            get { return SQLite.Table<AreaTriggerEntry>(); }
        }
    }
}
