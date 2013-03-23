using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    class CharacterCreationOutfit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public RaceID Race { get; set; }
        public ClassID Class { get; set; }
        public Gender Gender { get; set; }
        public byte Pad { get; set; }
        public int Items { get; set; }
        public int DisplayInfo { get; set; }
        public int InventoryType { get; set; }
    }
}
