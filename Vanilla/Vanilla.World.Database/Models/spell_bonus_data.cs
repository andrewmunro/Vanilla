using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_bonus_data", Schema="dbo")]

    public partial class spell_bonus_data
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("direct_bonus")] 
		        public float direct_bonus { get; set; }
 
        [Column("dot_bonus")] 
		        public float dot_bonus { get; set; }
 
        [Column("ap_bonus")] 
		        public float ap_bonus { get; set; }
 
        [Column("ap_dot_bonus")] 
		        public float ap_dot_bonus { get; set; }
 
        [Column("comments")] 
		        public string comments { get; set; }
    }
}
