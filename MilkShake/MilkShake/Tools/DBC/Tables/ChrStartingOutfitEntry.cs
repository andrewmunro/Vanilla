using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Character;

namespace Milkshake.Tools.DBC.Tables
{
    public class ChrStartingOutfitEntry
    {
        public int Race { get; set; }
        public int Class { get; set; }
        public int Gender { get; set; }
        public string ItemID { get; set; }
        public string ItemDisplayID { get; set; }
        public string ItemInventoryType { get; set; }
    }
}
