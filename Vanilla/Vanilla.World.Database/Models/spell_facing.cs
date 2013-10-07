using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("spell_facing", Schema="mangos")]

    public partial class spell_facing
    {
 
        [Column("entry")] 
		        public long entry { get; set; }
 
        [Column("facingcasterflag")] 
		        public bool facingcasterflag { get; set; }
    }
}
