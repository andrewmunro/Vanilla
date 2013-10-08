using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("playercreateinfo", Schema="mangos")]

    public partial class playercreateinfo
    {
 
        [Column("race")] 
		        public byte race { get; set; }
 
        [Column("class")] 
		        public byte @class { get; set; }
 
        [Column("map")] 
		        public int map { get; set; }
 
        [Column("zone")] 
		        public int zone { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
 
        [Column("orientation")] 
		        public float orientation { get; set; }
    }
}
