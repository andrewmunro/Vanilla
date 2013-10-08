using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("player_xp_for_level", Schema="mangos")]

    public partial class player_xp_for_level
    {
 
        [Column("lvl")] 
		        public long lvl { get; set; }
 
        [Column("xp_for_next_level")] 
		        public long xp_for_next_level { get; set; }
    }
}
