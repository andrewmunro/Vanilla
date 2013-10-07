using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("spell_learn_spell", Schema="mangos")]

    public partial class spell_learn_spell
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("SpellID")] 
		        public int SpellID { get; set; }
 
        [Column("Active")] 
		        public byte Active { get; set; }
    }
}
