using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_battleground_data", Schema="characters")]

    public partial class character_battleground_data
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("instance_id")] 
		        public long instance_id { get; set; }
 
        [Column("team")] 
		        public long team { get; set; }
 
        [Column("join_x")] 
		        public float join_x { get; set; }
 
        [Column("join_y")] 
		        public float join_y { get; set; }
 
        [Column("join_z")] 
		        public float join_z { get; set; }
 
        [Column("join_o")] 
		        public float join_o { get; set; }
 
        [Column("join_map")] 
		        public int join_map { get; set; }
    }
}
