using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("game_tele", Schema="mangos")]

    public partial class game_tele
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
 
        [Column("orientation")] 
		        public float orientation { get; set; }
 
        [Column("map")] 
		        public int map { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
    }
}
