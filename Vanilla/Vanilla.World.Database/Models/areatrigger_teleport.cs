using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("areatrigger_teleport", Schema="mangos")]

    public partial class areatrigger_teleport
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("required_level")] 
		        public byte required_level { get; set; }
 
        [Column("required_item")] 
		        public int required_item { get; set; }
 
        [Column("required_item2")] 
		        public int required_item2 { get; set; }
 
        [Column("required_quest_done")] 
		        public long required_quest_done { get; set; }
 
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
