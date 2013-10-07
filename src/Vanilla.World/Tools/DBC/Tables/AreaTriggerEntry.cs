using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.DBC.Tables
{
    public class AreaTriggerEntry
    {
        public int ID { get; set; }
        public int MapID { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Radius { get; set; }
        public float BoxX { get; set; }
        public float BoxY { get; set; }
        public float BoxZ { get; set; }
        public float BoxOrientation { get; set; }
    }
}
