using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_honor_cp", Schema="characters")]

    public partial class character_honor_cp
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("victim_type")] 
		        public byte victim_type { get; set; }
 
        [Column("victim")] 
		        public long victim { get; set; }
 
        [Column("honor")] 
		        public float honor { get; set; }
 
        [Column("date")] 
		        public long date { get; set; }
 
        [Column("type")] 
		        public byte type { get; set; }
    }
}
