using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.DBC.Tables
{
    public class AreaTableEntry
    {
        public int ID { get; set; }
        public int MapID { get; set; }
        public string Name { get; set; }
        public int Zone { get; set; }
        public int ExploreFlag { get; set; }
        public int Flag { get; set; }
        public int Team { get; set; }
    }
}
