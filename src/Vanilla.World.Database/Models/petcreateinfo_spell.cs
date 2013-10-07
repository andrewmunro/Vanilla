using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("petcreateinfo_spell", Schema="mangos")]

    public partial class petcreateinfo_spell
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("Spell1")] 
		        public int Spell1 { get; set; }
 
        [Column("Spell2")] 
		        public int Spell2 { get; set; }
 
        [Column("Spell3")] 
		        public int Spell3 { get; set; }
 
        [Column("Spell4")] 
		        public int Spell4 { get; set; }
    }
}
