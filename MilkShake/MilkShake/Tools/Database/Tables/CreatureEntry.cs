using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.Database.Tables
{
    public class CreatureEntry
    {
        public int guid { get; set; }
        public int id { get; set; }
        public int map { get; set; }
        public int modelid { get; set; }
        public int equipment_id { get; set; }
        public float position_x { get; set; }
        public float position_y { get; set; }
        public float position_z { get; set; }
        public float orientation { get; set; }
        public int spawntimesecs { get; set; }
        public int spawndist { get; set; }
        public int currentwaypoint { get; set; }
        public int curhealth { get; set; }
        public int curmana { get; set; }
        public int DeathState { get; set; }
        public int MovementType { get; set; }
    }
}
