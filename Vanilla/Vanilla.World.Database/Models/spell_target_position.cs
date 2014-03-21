using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_target_position", Schema="dbo")]

    public partial class spell_target_position
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("target_map")] 
		        public int target_map { get; set; }
 
        [Column("target_position_x")] 
		        public float target_position_x { get; set; }
 
        [Column("target_position_y")] 
		        public float target_position_y { get; set; }
 
        [Column("target_position_z")] 
		        public float target_position_z { get; set; }
 
        [Column("target_orientation")] 
		        public float target_orientation { get; set; }
    }
}
