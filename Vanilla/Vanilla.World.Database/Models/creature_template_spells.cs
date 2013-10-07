using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("creature_template_spells", Schema="mangos")]

    public partial class creature_template_spells
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("spell1")] 
		        public int spell1 { get; set; }
 
        [Column("spell2")] 
		        public int spell2 { get; set; }
 
        [Column("spell3")] 
		        public int spell3 { get; set; }
 
        [Column("spell4")] 
		        public int spell4 { get; set; }
    }
}
