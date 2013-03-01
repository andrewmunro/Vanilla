using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.DBC.Tables
{
    public class ChrRacesEntry
    {
        public int RaceID { get; set; }
        public string DisplayName { get; set; }
        public int FactionID { get; set; }

        public int ModelM { get; set; }
        public int ModelF { get; set; }

        public int TeamID { get; set; }
        public int StartingTaxiMask { get; set; }
        public int CinematicSequence { get; set; }
    }
}
