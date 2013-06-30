using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.Database.Tables
{
    class CharacterInventory
    {
        public int GUID { get; set; }
        public int Bag { get; set; }
        public int Slot { get; set; }
        public int Item { get; set; }
        public int ItemTemplate { get; set; }
    }
}
