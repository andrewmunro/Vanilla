using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    public class GameObjectTemplate
    {
        [PrimaryKey, AutoIncrement]
        public int Entry { get; set; }

        public int Type { get; set; }
        public int DisplayID { get; set; }
        public string Name { get; set; }
        public int Faction { get; set; }
        public int Flag { get; set; }
        public float Size { get; set; }
    }
}
