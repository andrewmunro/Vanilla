using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    class CharacterSpell
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int GUID { get; set; }
        public int SpellID { get; set; }
    }
}
