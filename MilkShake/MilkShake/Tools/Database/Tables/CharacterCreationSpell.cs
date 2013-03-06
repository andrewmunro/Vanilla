using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    class CharacterCreationSpell
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public RaceID Race { get; set; }
        public ClassID Class { get; set; }
        public int SpellID { get; set; }
    }
}
