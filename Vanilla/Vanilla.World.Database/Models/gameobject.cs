using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("gameobject", Schema="mangos")]

    public partial class gameobject
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("map")] 
		        public int map { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
 
        [Column("orientation")] 
		        public float orientation { get; set; }
 
        [Column("rotation0")] 
		        public float rotation0 { get; set; }
 
        [Column("rotation1")] 
		        public float rotation1 { get; set; }
 
        [Column("rotation2")] 
		        public float rotation2 { get; set; }
 
        [Column("rotation3")] 
		        public float rotation3 { get; set; }
 
        [Column("spawntimesecs")] 
		        public int spawntimesecs { get; set; }
 
        [Column("animprogress")] 
		        public byte animprogress { get; set; }
 
        [Column("state")] 
		        public byte state { get; set; }
    }
}
