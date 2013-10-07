using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("game_graveyard_zone", Schema="mangos")]

    public partial class game_graveyard_zone
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("ghost_zone")] 
		        public int ghost_zone { get; set; }
 
        [Column("faction")] 
		        public int faction { get; set; }
    }
}
