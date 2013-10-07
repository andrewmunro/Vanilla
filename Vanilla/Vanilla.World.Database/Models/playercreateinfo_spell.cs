using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("playercreateinfo_spell", Schema="mangos")]

    public partial class playercreateinfo_spell
    {
 
        [Column("race")] 
		        public byte race { get; set; }
 
        [Column("class")] 
		        public byte @class { get; set; }
 
        [Column("Spell")] 
		        public int Spell { get; set; }
 
        [Column("Note")] 
		        public string Note { get; set; }
    }
}
