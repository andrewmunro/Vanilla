using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("character_homebind", Schema="characters")]

    public partial class character_homebind
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("map")] 
		        public long map { get; set; }
 
        [Column("zone")] 
		        public long zone { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
    }
}
