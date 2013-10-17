using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_threat", Schema="mangos")]

    public partial class spell_threat
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("Threat")] 
		        public short Threat { get; set; }
 
        [Column("multiplier")] 
		        public float multiplier { get; set; }
 
        [Column("ap_bonus")] 
		        public float ap_bonus { get; set; }
    }
}
