using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    public class ChannelCharacter
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int GUID { get; set; }
        public int ChannelID { get; set; }
    }
}
