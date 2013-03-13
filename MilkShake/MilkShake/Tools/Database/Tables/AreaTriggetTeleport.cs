using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    public class AreaTriggerTeleport
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public int RequiredItem { get; set; }
        public int RequiredItem2 { get; set; }
        public int RequiredQuestDone { get; set; }
        public int RequiredFailedText { get; set; }
        public int TargetMap { get; set; }
        public float TargetX { get; set; }
        public float TargetY { get; set; }
        public float TargetZ { get; set; }
        public float TargetR { get; set; }
    }
}
