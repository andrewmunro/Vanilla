using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_reputation", Schema="characters")]

    public partial class character_reputation
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("faction")] 
		        public long faction { get; set; }
 
        [Column("standing")] 
		        public int standing { get; set; }
 
        [Column("flags")] 
		        public int flags { get; set; }
    }
}
