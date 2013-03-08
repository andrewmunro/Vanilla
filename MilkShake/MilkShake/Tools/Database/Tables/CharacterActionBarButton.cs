using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    class CharacterActionBarButton
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int GUID { get; set; }
        public int Button { get; set; }
        public int Action { get; set; }
        public int Type { get; set; }
    }
}
