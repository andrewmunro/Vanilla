using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("creature", Schema="mangos")]

    public partial class creature
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("map")] 
		        public int map { get; set; }
 
        [Column("modelid")] 
		        public int modelid { get; set; }
 
        [Column("equipment_id")] 
		        public int equipment_id { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
 
        [Column("orientation")] 
		        public float orientation { get; set; }
 
        [Column("spawntimesecs")] 
		        public long spawntimesecs { get; set; }
 
        [Column("spawndist")] 
		        public float spawndist { get; set; }
 
        [Column("currentwaypoint")] 
		        public int currentwaypoint { get; set; }
 
        [Column("curhealth")] 
		        public long curhealth { get; set; }
 
        [Column("curmana")] 
		        public long curmana { get; set; }
 
        [Column("DeathState")] 
		        public byte DeathState { get; set; }
 
        [Column("MovementType")] 
		        public byte MovementType { get; set; }
    }
}
