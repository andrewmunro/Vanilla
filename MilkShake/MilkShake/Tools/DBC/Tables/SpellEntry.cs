using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.DBC.Tables
{
    public class SpellEntry
    {
        public int ID { get; set; }
        public int School { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }

        public int Cooldown { get; set; }
        public int CooldownCatagory { get; set; }
    }
}
